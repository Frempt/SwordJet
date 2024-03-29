﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SwordJet
{
    public partial class TournamentSetupForm : Form
    {
        private string FilePath;
        private bool loading = false;

        public Tournament tournament;

        public TournamentSetupForm(string filePath)
        {
            InitializeComponent();

            //load config drop down lists
            foreach (var item in Enum.GetValues(typeof(Tournament.EliminationType))) { ddlElimType.Items.Add(item); }
            foreach (var item in Enum.GetValues(typeof(Tournament.PoolType))) { ddlPoolType.Items.Add(item); }
            foreach (var item in ConfigValues.eliminationSizes) { ddlElimSize.Items.Add(item); }
            foreach (var item in Enum.GetValues(typeof(Tournament.AfterblowBehaviour))) { ddlAfterblowBehaviour.Items.Add(item); }
            foreach (var item in Enum.GetValues(typeof(Tournament.PenaltyBehaviour))) { ddlPenaltyBehaviour.Items.Add(item); }

            FilePath = filePath;
            LoadTournament();

            //load countries list
            ddlNationality.DataSource = Country.Countries;
            ddlNationality.SelectedItem = Country.Countries.Where(c => c.code == "GB").First();

            ddlClub.DataSource = tournament.clubs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ensure a name has been entered
            if (txtName.Text != "")
            {
                try
                {
                    //add the new fighter to the list with the next ID, and refresh the listbox
                    Fighter fighter = new Fighter(tournament.GetNextFighterID(), txtName.Text);
                    fighter.club = ddlClub.Text;
                    fighter.country = ((Country)ddlNationality.SelectedItem).code;
                    tournament.fighters.Add(fighter);

                    lstFighters.DataSource = null;
                    lstFighters.DataSource = tournament.fighters;

                    lblFighterCount.Text = "Number of Fighters: " + tournament.fighters.Count;

                    txtName.Text = "";
                    ddlNationality.SelectedItem = Country.Countries.Where(c => c.code == "GB").First();

                    //recalculate the pool length message
                    //CalculateMessage();

                    txtName.Focus();

                    //save changes
                    FileAccessHelper.SaveTournament(tournament, FilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding fighter to tournament - " + ex.Message);
                    Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
                }

                LoadTournament();
            }
        }

        //build the time message
        private void CalculateMessage()
        {
            int numFighters = tournament.fighters.Count;
            int numPools = (int)txtPools.Value;
            int numRounds = (int)txtRounds.Value;
            int fightersPerPool = (numFighters / numPools);

            //only valid if there are more fighters in each pool than rounds - otherwise fights will be repeated
            if (numFighters > 2 && fightersPerPool > Math.Max(3, numRounds))
            {
                //caclulate the number of fights there will be in total
                int numFights = numFighters * numRounds;
                int fightLength = (int)txtFightTime.Value;

                StringBuilder message = new StringBuilder();
                message.Append(numFights);
                message.Append(" total fights at ");
                message.Append(fightLength);
                message.Append(" minutes maximum time means a total of ");

                //calculate total maximum length of fighting time
                double totalTime = (fightLength * numFights)/numPools;

                if (totalTime > 60)
                {
                    int totalHours = (int)Math.Floor((totalTime / 60));
                    message.Append(totalHours);
                    message.Append(" ");
                    message.Append((totalHours == 1) ? "hour " : "hours ");

                    totalTime -= totalHours * 60;
                }

                if(totalTime > 0)
                {
                    message.Append(totalTime);
                    message.Append(" ");
                    message.Append((totalTime == 1.0) ? "minute " : "minutes ");
                }

                message.Append("maximum fighting time per pool.");

                //lblLengthMessage.Text = message.ToString();
            }
            else
            {
                //lblLengthMessage.Text = "Insufficient fighters for number of pools/rounds.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //remove selected fighter
            if(lstFighters.SelectedItem != null)
            {
                tournament.fighters.RemoveAt(lstFighters.SelectedIndex);
                lstFighters.DataSource = null;
                lstFighters.DataSource = tournament.fighters;

                lblFighterCount.Text = "Number of Fighters: " + tournament.fighters.Count;

                //CalculateMessage();

                //save changes
                SaveTournament();
            }
        }

        private void upDown_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                //recalulate pool length message
                //CalculateMessage();

                //save changes
                SaveTournament();
            }
        }

        private void SaveTournament()
        {
            try
            {
                tournament.numberOfPools = (int)txtPools.Value;
                tournament.numberOfRounds = (int)txtRounds.Value;
                tournament.name = txtTournamentName.Text;
                tournament.winPoints = (int)txtWinPoints.Value;
                tournament.drawPoints = (int)txtDrawPoints.Value;
                tournament.lossPoints = (int)txtLossPoints.Value;
                tournament.fightTimeMinutes = (int)txtFightTime.Value;
                tournament.fightTimeMinutesFinal = (int)txtFinalFightTime.Value;
                tournament.scoreThreshold = (chkScoreCap.Checked) ? (int?)txtScoreCap.Value : null;
                tournament.scoreThresholdFinal = (chkFinalScoreCap.Checked) ? (int?)txtFinalScoreCap.Value : null;
                tournament.doubleThreshold = (chkDoubleOut.Checked) ? (int?)txtDoubleLimit.Value : null;
                tournament.penaltyThreshold = (int)txtPenaltyThreshold.Value;
                tournament.afterblowBehaviour = (Tournament.AfterblowBehaviour)ddlAfterblowBehaviour.SelectedItem;
                tournament.penaltyBehaviour = (Tournament.PenaltyBehaviour)ddlPenaltyBehaviour.SelectedItem;
                tournament.poolType = (Tournament.PoolType)ddlPoolType.SelectedItem;
                tournament.eliminationSize = int.Parse(ddlElimSize.SelectedItem.ToString());
                tournament.eliminationType = (Tournament.EliminationType)ddlElimType.SelectedItem;

                FileAccessHelper.SaveTournament(tournament, FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving tournament - " + ex.Message);
                Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
            }

            LoadTournament();
        }

        private void LoadTournament()
        {
            loading = true;

            try
            {
                tournament = FileAccessHelper.LoadTournament(FilePath);

                txtPools.Value = tournament.numberOfPools;
                txtRounds.Value = tournament.numberOfRounds;
                txtTournamentName.Text = tournament.name;
                ddlElimType.SelectedItem = tournament.eliminationType;
                ddlPoolType.SelectedItem = tournament.poolType;
                ddlElimSize.SelectedItem = tournament.eliminationSize;
                txtWinPoints.Value = tournament.winPoints;
                txtDrawPoints.Value = tournament.drawPoints;
                txtLossPoints.Value = tournament.lossPoints;
                txtFightTime.Value = tournament.fightTimeMinutes;
                txtFinalFightTime.Value = tournament.fightTimeMinutesFinal;
                chkScoreCap.Checked = (tournament.scoreThreshold != null);
                chkFinalScoreCap.Checked = (tournament.scoreThresholdFinal != null);
                if (tournament.scoreThreshold != null) txtScoreCap.Value = (int)tournament.scoreThreshold;
                if (tournament.scoreThresholdFinal != null) txtFinalScoreCap.Value = (int)tournament.scoreThresholdFinal;
                chkDoubleOut.Checked = (tournament.doubleThreshold != null);
                if (tournament.doubleThreshold != null) txtDoubleLimit.Value = (int)tournament.doubleThreshold;
                txtPenaltyThreshold.Value = tournament.penaltyThreshold;
                ddlPenaltyBehaviour.SelectedItem = tournament.penaltyBehaviour;
                ddlAfterblowBehaviour.SelectedItem = tournament.afterblowBehaviour;

                lstFighters.DataSource = tournament.fighters;
                lblFighterCount.Text = "Number of Fighters: " + tournament.fighters.Count;

                //CalculateMessage();

                if (tournament.stage != Tournament.TournamentStage.REGISTRATION)
                {
                    button1.Enabled = false;
                    btnDelete.Enabled = false;
                    txtScoreCap.Enabled = false;
                    txtFinalScoreCap.Enabled = false;
                    txtDoubleLimit.Enabled = false;
                    txtPenaltyThreshold.Enabled = false;
                    ddlPenaltyBehaviour.Enabled = false;
                    ddlAfterblowBehaviour.Enabled = false;
                    txtDrawPoints.Enabled = false;
                    txtWinPoints.Enabled = false;
                    txtLossPoints.Enabled = false;
                    txtPools.Enabled = false;
                    txtRounds.Enabled = false;
                    txtFightTime.Enabled = false;
                    txtFinalFightTime.Enabled = false;
                    txtName.Enabled = false;
                    ddlClub.Enabled = false;
                    btnClubEdit.Enabled = false;
                    ddlNationality.Enabled = false;
                    chkScoreCap.Enabled = false;
                    chkFinalScoreCap.Enabled = false;
                    chkDoubleOut.Enabled = false;
                    txtTournamentName.Enabled = false;
                    ddlPoolType.Enabled = false;
                    lstFighters.Enabled = false;

                    if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS)
                    {
                        ddlElimType.Enabled = false;
                        ddlElimSize.Enabled = false;
                    }
                }

                loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tournament - " + ex.Message);
                Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageTournament manager = new ManageTournament(FilePath);
            manager.Show();
        }

        private void ddlPoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tournament.PoolType poolType = (Tournament.PoolType)ddlPoolType.SelectedItem;

            switch(poolType) 
            {
                case Tournament.PoolType.FIXEDROUNDS:
                    txtPools.Enabled = true;
                    txtRounds.Enabled = true;
                    break;

                case Tournament.PoolType.ROUNDROBIN:
                    txtPools.Enabled = true;
                    txtRounds.Enabled = false;
                    break;

                case Tournament.PoolType.SWISSPAIRS:
                    txtPools.Enabled = false;
                    txtRounds.Enabled = false;
                    break;
            }

            if (!loading)
            {
                //recalulate pool length message
                //CalculateMessage();

                //save changes
                SaveTournament();
            }
        }

        private void TournamentSetupForm_Activated(object sender, EventArgs e)
        {
            LoadTournament();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button1.PerformClick();
            }
        }

        private void btnClubEdit_Click(object sender, EventArgs e)
        {
            EditClubs dialog = new EditClubs(tournament.clubs);

            DialogResult res = dialog.ShowDialog();

            tournament.clubs.Clear();
            tournament.clubs = dialog.clubList;
            SaveTournament();

            ddlClub.DataSource = null;
            ddlClub.DataSource = tournament.clubs;
        }

        private void lstFighters_onCheck(object sender, ItemCheckEventArgs e)
        {            
            tournament.fighters[e.Index].seed = e.NewValue == CheckState.Checked ? 1 : 0;
            SaveTournament();
        }
    }
}
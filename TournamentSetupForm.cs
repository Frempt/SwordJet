using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace TournamentGenerator
{
    public partial class TournamentSetupForm : Form
    {
        private string FilePath;
        private bool loading = false;

        public Tournament tournament;

        public TournamentSetupForm(string filePath)
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(Tournament.EliminationType))) { ddlElimType.Items.Add(item); }
            foreach (var item in Enum.GetValues(typeof(Tournament.PoolType))) { ddlPoolType.Items.Add(item); }
            foreach (var item in ConfigValues.eliminationSizes) { ddlElimSize.Items.Add(item); }

            FilePath = filePath;
            LoadTournament();

            ddlNationality.DataSource = Country.Countries;
            ddlNationality.SelectedItem = Country.Countries.Where(c => c.code == "GB").First();

            ddlClub.DataSource = tournament.clubs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ensure a name has been entered
            if (txtName.Text != "")
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

                //recalculate the pool length message
                CalculateMessage();

                txtName.Focus();

                //save changes
                FileAccessHelper.SaveTournament(tournament, FilePath);

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

                lblLengthMessage.Text = message.ToString();
            }
            else
            {
                lblLengthMessage.Text = "Insufficient fighters for number of pools/rounds.";
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

                CalculateMessage();

                //save changes
                SaveTournament();
            }
        }

        private void upDown_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                //recalulate pool length message
                CalculateMessage();

                //save changes
                SaveTournament();
            }
        }

        private void SaveTournament()
        {
            tournament.numberOfPools = (int)txtPools.Value;
            tournament.numberOfRounds = (int)txtRounds.Value;
            tournament.name = txtTournamentName.Text;
            tournament.winPoints = (int)txtWinPoints.Value;
            tournament.drawPoints = (int)txtDrawPoints.Value;
            tournament.lossPoints = (int)txtLossPoints.Value;
            tournament.fightTimeMinutes = (int)txtFightTime.Value;
            tournament.doubleThreshold = (chkDoubleOut.Checked) ? (int?)txtDoubleLimit.Value : null;
            tournament.poolType = (Tournament.PoolType)ddlPoolType.SelectedItem;
            tournament.eliminationSize = int.Parse(ddlElimSize.SelectedItem.ToString());
            tournament.eliminationType = (Tournament.EliminationType)ddlElimType.SelectedItem;

            FileAccessHelper.SaveTournament(tournament, FilePath);

            LoadTournament();
        }

        private void LoadTournament()
        {
            loading = true;

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
            chkDoubleOut.Checked = (tournament.doubleThreshold != null);
            if (tournament.doubleThreshold != null) txtDoubleLimit.Value = (int)tournament.doubleThreshold;

            lstFighters.DataSource = tournament.fighters;
            lblFighterCount.Text = "Number of Fighters: " + tournament.fighters.Count;

            CalculateMessage();

            if (tournament.stage != Tournament.TournamentStage.REGISTRATION)
            {
                button1.Enabled = false;
                btnDelete.Enabled = false;
                txtDoubleLimit.Enabled = false;
                txtDrawPoints.Enabled = false;
                txtWinPoints.Enabled = false;
                txtLossPoints.Enabled = false;
                txtPools.Enabled = false;
                txtRounds.Enabled = false;
                txtFightTime.Enabled = false;
                txtName.Enabled = false;
                ddlClub.Enabled = false;
                btnClubEdit.Enabled = false;
                ddlNationality.Enabled = false;
                chkDoubleOut.Enabled = false;
                txtTournamentName.Enabled = false;
                ddlPoolType.Enabled = false;

                if(tournament.stage != Tournament.TournamentStage.POOLFIGHTS)
                {
                    ddlElimType.Enabled = false;
                    ddlElimSize.Enabled = false;
                }
            }

            loading = false;
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
                CalculateMessage();

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
    }
}
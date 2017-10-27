﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TournamentGenerator
{
    public partial class ManageTournament : Form
    {
        private string FilePath;
        private Tournament tournament;

        public ManageTournament(string filePath)
        {
            InitializeComponent();

            FilePath = filePath;
        }

        private void ManageTournament_Load(object sender, EventArgs e)
        {
            LoadTournament();
        }

        private void LoadFighters()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Pool");
            table.Columns.Add("Score");
            table.Columns.Add("Doubles");

            foreach (Fighter fighter in tournament.fighters)
            {
                DataRow row = table.NewRow();

                row["Name"] = fighter.name;

                string poolname = "";
                foreach (Pool p in tournament.pools)
                {
                    if (p.fighters.Contains(fighter.id)) poolname = p.name;
                }
                row["Pool"] = poolname;

                row["Score"] = tournament.GetFighterScore(fighter);

                row["Doubles"] = tournament.GetFighterDoubles(fighter);

                table.Rows.Add(row);
            }

            DataView dv = table.DefaultView;
            dv.Sort = "Score DESC, Doubles ASC";

            dgvFighters.DataSource = dv;
        }

        private void LoadTournament()
        {
            tournament = FileAccessHelper.LoadTournament(FilePath);

            string advanceButtonText = "";

            switch (tournament.stage)
            {
                case Tournament.TournamentStage.REGISTRATION:
                    advanceButtonText = "Begin Pools";
                    break;

                case Tournament.TournamentStage.POOLFIGHTS:
                    advanceButtonText = "Begin Eliminations";
                    break;

                case Tournament.TournamentStage.ELIMINATIONS:
                    advanceButtonText = "Next Elimination Round";

                    if (tournament.eliminations.Last().fighters.Count == 4)
                    {
                        advanceButtonText = "Begin Finals";
                    }

                    break;

                case Tournament.TournamentStage.FINALS:
                    advanceButtonText = "End Tournament";
                    break;
            }

            btnAdvance.Text = advanceButtonText;

            LoadFighters();

            tbcFights.TabPages.Clear();

            foreach (Pool pool in tournament.pools)
            {
                TabPage page = new TabPage("POOL - " + pool.name);
                page.Width = tbcFights.Width;
                page.Height = tbcFights.Height;

                TabControl childTabs = new TabControl();
                childTabs.SizeMode = TabSizeMode.FillToRight;
                childTabs.Top = 0;
                childTabs.Left = 0;
                childTabs.Width = page.Width;
                childTabs.Height = page.Height;

                for (int i = 0; i < pool.rounds.Count; i++)
                {
                    List<Fight> round = pool.rounds[i];

                    TabPage childPage = new TabPage("Round " + (i + 1));
                    childPage.Width = childTabs.Width;
                    childPage.Height = childTabs.Height;

                    TableLayoutPanel panel = new TableLayoutPanel();
                    panel.Width = childPage.Width;
                    panel.Height = childPage.Height;

                    Font boldFont = new Font(Font, FontStyle.Bold);

                    Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                    panel.Controls.Add(fighterALabel, 0, 0);
                    panel.SetColumnSpan(fighterALabel, 2);

                    Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                    panel.Controls.Add(fighterBLabel, 3, 0);
                    panel.SetColumnSpan(fighterBLabel, 2);

                    panel.Controls.Add(new Label() { Text = "Doubles", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter }, 5, 0);

                    for (int j = 0; j < round.Count; j++)
                    {
                        Fight fight = round[j];

                        Fighter fighterA = tournament.GetFighterByID(fight.fighterA);
                        Fighter fighterB = tournament.GetFighterByID(fight.fighterB);

                        int rowIndex = j + 1;

                        panel.Controls.Add(new Label() { Text = fighterA.name }, 0, rowIndex);

                        ComboBox ddlResultA = new ComboBox();
                        ddlResultA.Tag = fight.fightID;
                        ddlResultA.Name = "AResult";
                        ddlResultA.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (var item in Enum.GetValues(typeof(Fight.FightResult))) { ddlResultA.Items.Add(item); }
                        ddlResultA.SelectedItem = fight.fighterAResult;
                        ddlResultA.SelectedValueChanged += control_ValueChanged;
                        if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) ddlResultA.Enabled = false;
                        panel.Controls.Add(ddlResultA, 1, rowIndex);

                        panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                        panel.Controls.Add(new Label() { Text = fighterB.name }, 3, rowIndex);

                        ComboBox ddlResultB = new ComboBox();
                        ddlResultB.Tag = fight.fightID;
                        ddlResultB.Name = "BResult";
                        ddlResultB.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (var item in Enum.GetValues(typeof(Fight.FightResult))) { ddlResultB.Items.Add(item); }
                        ddlResultB.SelectedItem = fight.fighterBResult;
                        ddlResultB.SelectedValueChanged += control_ValueChanged;
                        if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) ddlResultB.Enabled = false;
                        panel.Controls.Add(ddlResultB, 4, rowIndex);

                        NumericUpDown txtDoubles = new NumericUpDown();
                        txtDoubles.Tag = fight.fightID;
                        txtDoubles.Name = "DBLCount";
                        txtDoubles.Increment = 1;
                        txtDoubles.Value = fight.doubleCount;
                        txtDoubles.ValueChanged += control_ValueChanged;
                        panel.Controls.Add(txtDoubles, 5, rowIndex);
                    }

                    childPage.Controls.Add(panel);
                    childTabs.TabPages.Add(childPage);
                }

                page.Controls.Add(childTabs);

                tbcFights.TabPages.Add(page);
            }

            for (int i = 0; i < tournament.eliminations.Count; i++)
            {
                Pool bracket = tournament.eliminations[i];

                TabPage page = new TabPage("ELIM - " + bracket.name);
                page.Width = tbcFights.Width;
                page.Height = tbcFights.Height;

                List<Fight> round = bracket.rounds[0];

                TableLayoutPanel panel = new TableLayoutPanel();
                panel.Width = page.Width;
                panel.Height = page.Height;

                Font boldFont = new Font(Font, FontStyle.Bold);

                Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                panel.Controls.Add(fighterALabel, 0, 0);
                panel.SetColumnSpan(fighterALabel, 2);

                Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                panel.Controls.Add(fighterBLabel, 3, 0);
                panel.SetColumnSpan(fighterBLabel, 2);

                for (int j = 0; j < round.Count; j++)
                {
                    Fight fight = round[j];

                    Fighter fighterA = tournament.GetFighterByID(fight.fighterA);
                    Fighter fighterB = tournament.GetFighterByID(fight.fighterB);

                    int rowIndex = j + 1;

                    panel.Controls.Add(new Label() { Text = fighterA.name }, 0, rowIndex);

                    RadioButton rbWinA = new RadioButton();
                    rbWinA.Text = "Win";
                    rbWinA.Tag = fight.fightID;
                    rbWinA.Name = "AResultRB";
                    rbWinA.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    if (tournament.stage != Tournament.TournamentStage.ELIMINATIONS || i != (tournament.eliminations.Count - 1)) rbWinA.Enabled = false;
                    panel.Controls.Add(rbWinA, 1, rowIndex);

                    panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                    panel.Controls.Add(new Label() { Text = fighterB.name }, 3, rowIndex);

                    RadioButton rbWinB = new RadioButton();
                    rbWinB.Text = "Win";
                    rbWinB.Tag = fight.fightID;
                    rbWinB.Name = "BResultRB";
                    rbWinB.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    if (tournament.stage != Tournament.TournamentStage.ELIMINATIONS || i != (tournament.eliminations.Count - 1)) rbWinB.Enabled = false;
                    panel.Controls.Add(rbWinB, 1, rowIndex);
                }

                page.Controls.Add(panel);
            }

            if(tournament.finals.Count > 0)
            {
                TabPage page = new TabPage("Finals");
                page.Width = tbcFights.Width;
                page.Height = tbcFights.Height;

                List<Fight> round = tournament.finals;

                TableLayoutPanel panel = new TableLayoutPanel();
                panel.Width = page.Width;
                panel.Height = page.Height;

                Font boldFont = new Font(Font, FontStyle.Bold);

                Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                panel.Controls.Add(fighterALabel, 0, 0);
                panel.SetColumnSpan(fighterALabel, 2);

                Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter };
                panel.Controls.Add(fighterBLabel, 3, 0);
                panel.SetColumnSpan(fighterBLabel, 2);

                for (int j = 0; j < round.Count; j++)
                {
                    Fight fight = round[j];

                    Fighter fighterA = tournament.GetFighterByID(fight.fighterA);
                    Fighter fighterB = tournament.GetFighterByID(fight.fighterB);

                    int rowIndex = j + 1;

                    panel.Controls.Add(new Label() { Text = fighterA.name }, 0, rowIndex);

                    RadioButton rbWinA = new RadioButton();
                    rbWinA.Text = "Win";
                    rbWinA.Tag = fight.fightID;
                    rbWinA.Name = "AResultRB";
                    rbWinA.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    if (tournament.stage != Tournament.TournamentStage.FINALS) rbWinA.Enabled = false;
                    panel.Controls.Add(rbWinA, 1, rowIndex);

                    panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                    panel.Controls.Add(new Label() { Text = fighterB.name }, 3, rowIndex);

                    RadioButton rbWinB = new RadioButton();
                    rbWinB.Text = "Win";
                    rbWinB.Tag = fight.fightID;
                    rbWinB.Name = "BResultRB";
                    rbWinB.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    if (tournament.stage != Tournament.TournamentStage.FINALS) rbWinB.Enabled = false;
                    panel.Controls.Add(rbWinB, 1, rowIndex);
                }

                page.Controls.Add(panel);
            }
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            Control changedControl = (Control)sender;
            Fight fight = tournament.GetFightByID((Guid)changedControl.Tag);

            if (changedControl.Name == "AResult")
            {
                Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                fight.fighterAResult = result;
            }
            else if (changedControl.Name == "BResult")
            {
                Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                fight.fighterBResult = result;
            }
            else if (changedControl.Name == "AResultRB")
            {
                RadioButton rbCtrl = (RadioButton)changedControl;

                fight.fighterAResult = (rbCtrl.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);

                Control[] ctrls = changedControl.Parent.Controls.Find("BResultRB", false);
                RadioButton rbCtrl2 = (RadioButton)ctrls.Where(ct => (Guid)ct.Tag == fight.fightID);
                rbCtrl2.Checked = (!rbCtrl.Checked);

                fight.fighterBResult = (rbCtrl2.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);
            }
            else if (changedControl.Name == "BResultRB")
            {
                RadioButton rbCtrl = (RadioButton)changedControl;

                fight.fighterBResult = (rbCtrl.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);

                Control[] ctrls = changedControl.Parent.Controls.Find("AResultRB", false);
                RadioButton rbCtrl2 = (RadioButton)ctrls.Where(ct => (Guid)ct.Tag == fight.fightID);
                rbCtrl2.Checked = (!rbCtrl.Checked);

                fight.fighterAResult = (rbCtrl2.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);
            }
            else if (changedControl.Name == "DBLCount")
            {
                fight.doubleCount = (int)((NumericUpDown)changedControl).Value;
            }

            //save changes
            FileAccessHelper.SaveTournament(tournament, FilePath);

            LoadFighters();
        }

        private void btnExtendPools_Click(object sender, EventArgs e)
        {
            if (tournament.ExtendPools())
            {
                FileAccessHelper.SaveTournament(tournament, FilePath);
                LoadTournament();
            }
            else
            {
                MessageBox.Show("Insufficient fighters per pool to generate a new round.");
            }
        }

        private void GenerateSpreadsheet()
        {
            string filename = "Tournament" + Guid.NewGuid() + ".xls";

            //create the file save dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel |*.xls";
            dialog.FileName = filename;
            dialog.CheckFileExists = false;

            //call the ShowDialog method to show the save dialog box.
            DialogResult userClickedOK = dialog.ShowDialog();

            //process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                filename = dialog.FileName;

                FileAccessHelper.GenerateSpreadsheet(tournament, filename);

                //open the spreadsheet
                System.Diagnostics.Process.Start(filename);
            }

            //cleanup
            dialog.Dispose();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            GenerateSpreadsheet();
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            DialogResult result;

            switch (tournament.stage)
            {
                case Tournament.TournamentStage.REGISTRATION:

                    //warn user that fighters cannot be changed once pools are created
                    result = MessageBox.Show("Once pools are created, the tournament details will be locked. Do you wish to advance to the pool fights?", "Are you sure?", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        tournament.GeneratePools();
                        tournament.stage = Tournament.TournamentStage.POOLFIGHTS;
                    }
                    break;

                case Tournament.TournamentStage.POOLFIGHTS:
                    if (tournament.IsComplete())
                    {
                        //warn user that pool results cannot be changed once eliminations are generated
                        result = MessageBox.Show("Once elimination brackets are created, the pool results will be locked. Do you wish to advance to the elimination fights?", "Are you sure?", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            tournament.GenerateNextEliminationBracket();
                            tournament.stage = Tournament.TournamentStage.ELIMINATIONS;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fights are not all complete!");
                    }
                    break;

                case Tournament.TournamentStage.ELIMINATIONS:
                    if (tournament.IsComplete())
                    {
                        //warn user that elimination bracket results cannot be changed once the next round is generated
                        result = MessageBox.Show("Once eliminations are progressed, the previous round's results will be locked. Do you wish to advance to the elimination fights?", "Are you sure?", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            //check if we are moving to the finals
                            if (tournament.eliminations.Last().fighters.Count == 4)
                            {
                                tournament.stage = Tournament.TournamentStage.FINALS;
                                tournament.GenerateFinals();
                            }
                            else
                            {
                                tournament.GenerateNextEliminationBracket();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fights are not all complete!");
                    }
                    break;

                case Tournament.TournamentStage.FINALS:
                    if (tournament.IsComplete())
                    {
                        result = MessageBox.Show("Once tournament is closed, the fight results will be locked. Do you wish to advance to the elimination fights?", "Are you sure?", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            tournament.stage = Tournament.TournamentStage.CLOSED;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fights are not all complete!");
                    }
                    break;

                default: break;
            }
        }
    }
}

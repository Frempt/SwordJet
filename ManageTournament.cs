using System;
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

            if (tournament.stage == Tournament.TournamentStage.CLOSED)
            {
                table.Columns.Add("FinishingRank", typeof(int));
            }

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Pool", typeof(string));
            table.Columns.Add("PoolScore", typeof(int));
            table.Columns.Add("PoolDoubles", typeof(int));
            table.Columns.Add("PoolBuchholz", typeof(int));

            foreach (Pool p in tournament.eliminations)
            {
                table.Columns.Add(p.name, typeof(string));
            }

            if(tournament.finals.Count > 0)
            {
                table.Columns.Add("Finals", typeof(string));
            }

            table.Columns.Add("TieBreakerScore", typeof(int));
            table.Columns.Add("ElimSort", typeof(int));

            foreach (Fighter fighter in tournament.fighters)
            {
                DataRow row = table.NewRow();

                if (tournament.stage == Tournament.TournamentStage.CLOSED)
                {
                    int rank = tournament.GetFighterFinalRank(fighter);
                    row["FinishingRank"] = rank; 
                }

                row["Name"] = fighter.name;

                string poolname = "";
                foreach (Pool p in tournament.pools)
                {
                    if (p.fighters.Contains(fighter.id)) poolname = p.name;
                }
                row["Pool"] = poolname;

                row["PoolScore"] = tournament.GetFighterScore(fighter);

                row["PoolDoubles"] = tournament.GetFighterDoubles(fighter);

                row["PoolBuchholz"] = tournament.GetFighterBuchholzScore(fighter);

                row["TieBreakerScore"] = tournament.GetFighterTieBreakerScore(fighter);

                Dictionary<string,string> elimResults = tournament.GetFighterEliminationResults(fighter);
                int elimSort = 0;

                for(int i = 0; i < tournament.eliminations.Count; i++)
                {
                    Pool p = tournament.eliminations[i];
                    string r = elimResults[p.name];
                    row[p.name] = r;
                    elimSort += ((r == "WIN") ? 2 * (i + 1) : ((r == "LOSS") ? 1 * (i + 1) : 0));
                }

                if (tournament.finals.Count > 0)
                {
                    string r = tournament.GetFighterFinalsResult(fighter);
                    row["Finals"] = r;
                    elimSort += ((r == "WIN") ? 2 * tournament.eliminations.Count : ((r == "LOSS") ? 1 * tournament.eliminations.Count : 0));
                }

                row["ElimSort"] = elimSort;
                table.Rows.Add(row);
            }

            DataView dv = table.DefaultView;
            dv.Sort = "ElimSort DESC, PoolScore DESC, PoolDoubles ASC, PoolBuchholz DESC, TieBreakerScore DESC";
            if (tournament.stage == Tournament.TournamentStage.CLOSED)
            {
                dv.Sort = "FinishingRank ASC, " + dv.Sort;
            }
            dgvFighters.DataSource = dv;

            //hide sorting columns
            dgvFighters.Columns["ElimSort"].Visible = false;
            dgvFighters.Columns["TieBreakerScore"].Visible = false;
        }

        private void LoadTournament()
        {
            tournament = FileAccessHelper.LoadTournament(FilePath);

            string advanceButtonText = "";

            btnExtendPools.Enabled = false;

            switch (tournament.stage)
            {
                case Tournament.TournamentStage.REGISTRATION:
                    advanceButtonText = "Begin Pools";
                    break;

                case Tournament.TournamentStage.POOLFIGHTS:
                    if (tournament.poolType == Tournament.PoolType.SWISSPAIRS && (tournament.pools.Count / 2) < tournament.numberOfRounds)
                    {
                        advanceButtonText = "Next round";
                    }
                    else
                    {
                        advanceButtonText = "Begin Eliminations";
                    }
                    btnExtendPools.Enabled = true;
                    break;

                case Tournament.TournamentStage.TIEBREAKERS:
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

                case Tournament.TournamentStage.CLOSED:
                    advanceButtonText = "---";
                    btnAdvance.Enabled = false;
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
                        if(fighterB == null)
                        {
                            fighterB = new Fighter(int.MaxValue, "Bye");
                        }

                        int rowIndex = j + 1;

                        panel.Controls.Add(new Label() { Text = fighterA.name, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

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

                        Color bgColour = panel.ForeColor;

                        if (fight.oddFight)
                        {
                            bgColour = Color.DarkGray;
                        }

                        panel.Controls.Add(new Label() { Text = fighterB.name, ForeColor = bgColour, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                        ComboBox ddlResultB = new ComboBox();
                        ddlResultB.Tag = fight.fightID;
                        ddlResultB.Name = "BResult";
                        ddlResultB.DropDownStyle = ComboBoxStyle.DropDownList;
                        foreach (var item in Enum.GetValues(typeof(Fight.FightResult))) { ddlResultB.Items.Add(item); }
                        ddlResultB.SelectedItem = fight.fighterBResult;
                        ddlResultB.SelectedValueChanged += control_ValueChanged;
                        ddlResultB.ForeColor = bgColour;
                        if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) ddlResultB.Enabled = false;
                        panel.Controls.Add(ddlResultB, 4, rowIndex);

                        NumericUpDown txtDoubles = new NumericUpDown();
                        txtDoubles.Tag = fight.fightID;
                        txtDoubles.Name = "DBLCount";
                        txtDoubles.Increment = 1;
                        txtDoubles.Value = fight.doubleCount;
                        txtDoubles.ValueChanged += control_ValueChanged;
                        if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) txtDoubles.Enabled = false;
                        panel.Controls.Add(txtDoubles, 5, rowIndex);

                        if (fight.oddFight)
                        {
                            panel.Controls.Add(new Label() { Text = "Odd fight", TextAlign = ContentAlignment.MiddleCenter }, 6, rowIndex);

                            if(tournament.poolType == Tournament.PoolType.SWISSPAIRS)
                            {
                                ddlResultA.SelectedItem = Fight.FightResult.WIN;
                                ddlResultB.SelectedItem = Fight.FightResult.LOSS;
                                ddlResultA.Enabled = false;
                                ddlResultB.Enabled = false;
                                txtDoubles.Enabled = false;
                            }
                        }
                    }

                    childPage.Controls.Add(panel);
                    childTabs.TabPages.Add(childPage);
                }

                page.Controls.Add(childTabs);

                tbcFights.TabPages.Add(page);
            }

            if (tournament.tieBreakers != null)
            {
                tbcFights.TabPages.Add(CreateEliminationTabPage(tournament.tieBreakers, "Tie Breaker"));
            }

            for (int i = 0; i < tournament.eliminations.Count; i++)
            {
                tbcFights.TabPages.Add(CreateEliminationTabPage(tournament.eliminations[i]));
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

                    CheckBox rbWinA = new CheckBox();
                    rbWinA.Text = "Win";
                    rbWinA.Tag = fight.fightID;
                    rbWinA.Name = "AResultRB";
                    rbWinA.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    rbWinA.CheckedChanged += control_ValueChanged;
                    if (tournament.stage != Tournament.TournamentStage.FINALS) rbWinA.Enabled = false;
                    panel.Controls.Add(rbWinA, 1, rowIndex);

                    panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                    panel.Controls.Add(new Label() { Text = fighterB.name }, 3, rowIndex);

                    CheckBox rbWinB = new CheckBox();
                    rbWinB.Text = "Win";
                    rbWinB.Tag = fight.fightID;
                    rbWinB.Name = "BResultRB";
                    rbWinB.Checked = (fight.fighterBResult == Fight.FightResult.WIN);
                    rbWinB.CheckedChanged += control_ValueChanged;
                    if (tournament.stage != Tournament.TournamentStage.FINALS) rbWinB.Enabled = false;
                    panel.Controls.Add(rbWinB, 4, rowIndex);

                    Label lbl = new Label();
                    lbl.Text = (j == 0) ? "BRONZE" : "GOLD";
                    lbl.Font = boldFont;
                    panel.Controls.Add(lbl, 5, rowIndex);
                }

                page.Controls.Add(panel);
                tbcFights.TabPages.Add(page);
            }
        }

        private TabPage CreateEliminationTabPage(Pool bracket, string pageNamePrefix = "ELIM", bool finals = false)
        {
            TabPage page = new TabPage(pageNamePrefix + " - " + bracket.name);
            page.Width = tbcFights.Width;
            page.Height = tbcFights.Height;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Width = page.Width;
            panel.Height = page.Height;

            Font boldFont = new Font(Font, FontStyle.Bold);

            foreach (List<Fight> r in bracket.rounds)
            {
                List<Fight> round = bracket.rounds[0];

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

                    CheckBox rbWinA = new CheckBox();
                    rbWinA.Text = "Win";
                    rbWinA.Tag = fight.fightID;
                    rbWinA.Name = "AResultRB";
                    rbWinA.Checked = (fight.fighterAResult == Fight.FightResult.WIN);
                    rbWinA.CheckedChanged += control_ValueChanged;
                    if (tournament.stage == Tournament.TournamentStage.CLOSED || !(tournament.IsLatestBracket(bracket))) rbWinA.Enabled = false;
                    panel.Controls.Add(rbWinA, 1, rowIndex);

                    panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                    panel.Controls.Add(new Label() { Text = fighterB.name }, 3, rowIndex);

                    CheckBox rbWinB = new CheckBox();
                    rbWinB.Text = "Win";
                    rbWinB.Tag = fight.fightID;
                    rbWinB.Name = "BResultRB";
                    rbWinB.Checked = (fight.fighterBResult == Fight.FightResult.WIN);
                    rbWinB.CheckedChanged += control_ValueChanged;
                    if (tournament.stage == Tournament.TournamentStage.CLOSED || !(tournament.IsLatestBracket(bracket))) rbWinB.Enabled = false;
                    panel.Controls.Add(rbWinB, 4, rowIndex);
                }
            }

            page.Controls.Add(panel);

            return page;
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
                CheckBox rbCtrl = (CheckBox)changedControl;

                fight.fighterAResult = (rbCtrl.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);

                Control[] ctrls = changedControl.Parent.Controls.Find("BResultRB", false);
                CheckBox rbCtrl2 = (CheckBox)ctrls.Where(ct => (Guid)ct.Tag == fight.fightID).First();
                rbCtrl2.Checked = (!rbCtrl.Checked);

                fight.fighterBResult = (rbCtrl2.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);
            }
            else if (changedControl.Name == "BResultRB")
            {
                CheckBox rbCtrl = (CheckBox)changedControl;

                fight.fighterBResult = (rbCtrl.Checked ? Fight.FightResult.WIN : Fight.FightResult.LOSS);

                Control[] ctrls = changedControl.Parent.Controls.Find("AResultRB", false);
                CheckBox rbCtrl2 = (CheckBox)ctrls.Where(ct => (Guid)ct.Tag == fight.fightID).First();
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
            DialogResult result = MessageBox.Show("Are you sure you want to generate another round of pool fights? This cannot be removed once added.", "Are you sure?", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
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

            result = MessageBox.Show("Once the tournament is advanced, details for this stage will be locked. Do you wish to advance to the next stage?", "Are you sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(tournament.AdvanceTournament());

                FileAccessHelper.SaveTournament(tournament, FilePath);
                LoadTournament();
            }
        }

        private void btnRatingsExport_Click(object sender, EventArgs e)
        {
            //todo add this feature
            MessageBox.Show("TODO: Add this feature :/");
        }
    }
}

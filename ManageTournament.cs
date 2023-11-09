using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwordJet
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

            SelectLastPage();
        }

        private void SelectLastPage()
        {
            bool done = false;
            foreach (TabPage pg in tbcFights.TabPages)
            {
                if(pg.Controls[0].GetType() == typeof(TabControl))
                {
                    TabControl subTabs = (TabControl)pg.Controls[0];
                    foreach(TabPage child in subTabs.TabPages)
                    {
                        if (!IsPageComplete(child))
                        {
                            tbcFights.SelectedTab = pg;
                            subTabs.SelectedTab = child;
                            done = true;
                            break;
                        }

                        tbcFights.SelectedTab = pg;
                        subTabs.SelectedTab = child;
                    }
                }
                else
                {
                    if (!IsPageComplete(pg))
                    {
                        tbcFights.SelectedTab = pg;
                        break;
                    }
                    tbcFights.SelectedTab = pg;
                }

                if (done) break;
            }
        }

        private bool IsPageComplete(TabPage page)
        {
            TableLayoutPanel pnl = (TableLayoutPanel)page.Controls[0];

            foreach(Control c in pnl.Controls)
            {
                if(c.GetType() == typeof(ComboBox))
                {
                    if ((Fight.FightResult)(((ComboBox)c).SelectedItem) == Fight.FightResult.PENDING) return false;
                }
                else if(c.GetType() == typeof(CheckBox))
                {
                    string pairedCtrlName = "AResultRB";
                    if (c.Name.StartsWith("A")) pairedCtrlName = "BResultRB";

                    Control[] ctrls = c.Parent.Controls.Find(pairedCtrlName, false);
                    CheckBox rbCtrl2 = (CheckBox)ctrls.Where(ct => ct.Tag.ToString() == c.Tag.ToString()).First();

                    if(!((CheckBox)c).Checked && !rbCtrl2.Checked) return false;
                }
            }

            return true;
        }

        private void LoadFighters()
        {
            try
            {
                //get the tournament fighters in a DataView for binding
                dgvFighters.DataSource = tournament.GetFightersDataView();

                //hide sorting/unneeded columns
                dgvFighters.Columns["ElimSort"].Visible = false;
                dgvFighters.Columns["TieBreakerScore"].Visible = false;
                dgvFighters.Columns["ID"].Visible = false;
                dgvFighters.Columns["PoolBuchholz"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tournament fighters - " + ex.Message);
                Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
            }
        }

        private void LoadTournament()
        {
            try
            {
                tournament = FileAccessHelper.LoadTournament(FilePath);

                btnExtendPools.Enabled = false;

                //setup UI elements depending on the tournament stage
                switch (tournament.stage)
                {
                    case Tournament.TournamentStage.REGISTRATION:
                        btnAdvance.Text = "Begin Pools";
                        break;

                    case Tournament.TournamentStage.POOLFIGHTS:
                        //if this is swiss pairs and we haven't completed all of the pool rounds, advance button is "Next Round"
                        //if (tournament.poolType == Tournament.PoolType.SWISSPAIRS && (tournament.pools.Count / 2) < tournament.numberOfRounds)
                        //{
                        //   btnAdvance.Text = "Next round";
                        //}
                        //else
                        //{
                        btnAdvance.Text = "Begin Eliminations";
                        //}

                        //we can't extend round robin
                        if (tournament.poolType != Tournament.PoolType.ROUNDROBIN) btnExtendPools.Enabled = true;
                        break;

                    case Tournament.TournamentStage.TIEBREAKERS:
                        btnAdvance.Text = "Begin Eliminations";
                        break;

                    case Tournament.TournamentStage.ELIMINATIONS:
                        btnAdvance.Text = "Next Elimination Round";

                        //if there's only 4 fighters, next elimination round is the finals
                        if (tournament.eliminations.Last().fighters.Count == 4)
                        {
                            btnAdvance.Text = "Begin Finals";
                        }

                        break;

                    case Tournament.TournamentStage.FINALS:
                        btnAdvance.Text = "End Tournament";
                        break;

                    case Tournament.TournamentStage.CLOSED:
                        btnAdvance.Text = "---";
                        btnAdvance.Enabled = false;
                        break;
                }

                //populate fighter table
                LoadFighters();

                List<object> frTemp = new List<object>();
                foreach (var item in Enum.GetValues(typeof(Fight.FightResult))) { frTemp.Add(item); }
                object[] fightResults = frTemp.ToArray();

                //clear the tab control so we can start fresh
                tbcFights.TabPages.Clear();

                foreach (Pool pool in tournament.pools)
                {
                    TabPage page = new TabPage("POOL - " + pool.name);
                    page.Width = tbcFights.Width;
                    page.Height = tbcFights.Height;
                    page.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                    TabControl childTabs = new TabControl();
                    childTabs.SizeMode = TabSizeMode.FillToRight;
                    childTabs.Top = 0;
                    childTabs.Left = 0;
                    childTabs.Width = page.Width;
                    childTabs.Height = page.Height;
                    childTabs.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                    for (int i = 0; i < pool.rounds.Count; i++)
                    {
                        List<Fight> round = pool.rounds[i];

                        TabPage childPage = new TabPage("Round " + (i + 1));
                        childPage.Width = childTabs.Width;
                        childPage.Height = childTabs.Height;
                        childPage.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

                        TableLayoutPanel panel = new TableLayoutPanel();
                        panel.Width = childPage.Width;
                        panel.Height = childPage.Height;
                        panel.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
                        panel.AutoScroll = true;

                        Font boldFont = new Font(Font, FontStyle.Bold);

                        Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red };
                        panel.Controls.Add(fighterALabel, 0, 0);
                        panel.SetColumnSpan(fighterALabel, 2);

                        Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Blue };
                        panel.Controls.Add(fighterBLabel, 3, 0);
                        panel.SetColumnSpan(fighterBLabel, 2);

                        panel.Controls.Add(new Label() { Text = "Doubles", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter }, 5, 0);

                        panel.Controls.Add(new Label(), 6, 0);
                        panel.Controls.Add(new Label(), 7, 0);

                        for (int j = 0; j < round.Count; j++)
                        {
                            Fight fight = round[j];

                            Fighter fighterA = tournament.GetFighterByID(fight.fighterA);
                            Fighter fighterB = tournament.GetFighterByID(fight.fighterB);
                            if (fighterB == null)
                            {
                                fighterB = new Fighter(int.MaxValue, "Bye");
                            }

                            int rowIndex = j + 1;

                            panel.Controls.Add(new Label() { Text = fighterA.name, TextAlign = ContentAlignment.MiddleCenter }, 0, rowIndex);

                            ComboBox ddlResultA = new ComboBox();
                            ddlResultA.Tag = fight.fightID;
                            ddlResultA.Name = "AResult";
                            ddlResultA.DropDownStyle = ComboBoxStyle.DropDownList;
                            ddlResultA.Items.AddRange(fightResults);
                            ddlResultA.SelectedItem = fight.fighterAResult;
                            ddlResultA.SelectedValueChanged += control_ValueChanged;
                            if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) ddlResultA.Enabled = false;
                            panel.Controls.Add(ddlResultA, 1, rowIndex);

                            panel.Controls.Add(new Label() { Text = " V " }, 2, rowIndex);

                            Color textColour = panel.ForeColor;

                            if (fight.oddFight)
                            {
                                textColour = Color.DarkGray;
                            }

                            panel.Controls.Add(new Label() { Text = fighterB.name, ForeColor = textColour, TextAlign = ContentAlignment.MiddleCenter }, 3, rowIndex);

                            ComboBox ddlResultB = new ComboBox();
                            ddlResultB.Tag = fight.fightID;
                            ddlResultB.Name = "BResult";
                            ddlResultB.DropDownStyle = ComboBoxStyle.DropDownList;
                            ddlResultB.Items.AddRange(fightResults);
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
                            if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) txtDoubles.Enabled = false;
                            panel.Controls.Add(txtDoubles, 5, rowIndex);

                            if (fight.oddFight)
                            {
                                panel.Controls.Add(new Label() { Text = "Odd fight", TextAlign = ContentAlignment.MiddleCenter }, 7, rowIndex);

                                if (tournament.poolType == Tournament.PoolType.SWISSPAIRS)
                                {
                                    ddlResultA.SelectedItem = Fight.FightResult.WIN;
                                    ddlResultB.SelectedItem = Fight.FightResult.LOSS;
                                    ddlResultA.Enabled = false;
                                    ddlResultB.Enabled = false;
                                    txtDoubles.Enabled = false;
                                }
                            }

                            Button manageButton = new Button();
                            manageButton.Text = "Manage Fight";
                            manageButton.Tag = fight.fightID;
                            manageButton.Click += btnManageFight_Click;
                            if (fight.fighterAResult != Fight.FightResult.PENDING && fight.fighterBResult != Fight.FightResult.PENDING) manageButton.Enabled = false;

                            panel.Controls.Add(manageButton, 6, rowIndex);
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

                if (tournament.finals.Count > 0)
                {
                    TabPage page = new TabPage("Finals");
                    page.Width = tbcFights.Width;
                    page.Height = tbcFights.Height;

                    List<Fight> round = tournament.finals;

                    TableLayoutPanel panel = new TableLayoutPanel();
                    panel.Width = page.Width;
                    panel.Height = page.Height;

                    Font boldFont = new Font(Font, FontStyle.Bold);

                    Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red };
                    panel.Controls.Add(fighterALabel, 0, 0);
                    panel.SetColumnSpan(fighterALabel, 2);

                    Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Blue };
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

                        Button manageButton = new Button();
                        manageButton.Text = "Manage Fight";
                        manageButton.Tag = fight.fightID;
                        manageButton.Click += btnManageFight_Click;
                        if (fight.fighterAResult != Fight.FightResult.PENDING && fight.fighterBResult != Fight.FightResult.PENDING) manageButton.Enabled = false;

                        panel.Controls.Add(manageButton, 6, rowIndex);
                    }

                    page.Controls.Add(panel);
                    tbcFights.TabPages.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tournament - " + ex.Message);
                Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
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

                Label fighterALabel = new Label() { Text = "Fighter A", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red };
                panel.Controls.Add(fighterALabel, 0, 0);
                panel.SetColumnSpan(fighterALabel, 2);

                Label fighterBLabel = new Label() { Text = "Fighter B", Font = boldFont, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Blue };
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

                    Button manageButton = new Button();
                    manageButton.Text = "Manage Fight";
                    manageButton.Tag = fight.fightID;
                    manageButton.Click += btnManageFight_Click;
                    if (fight.fighterAResult != Fight.FightResult.PENDING && fight.fighterBResult != Fight.FightResult.PENDING) manageButton.Enabled = false;

                    panel.Controls.Add(manageButton, 5, rowIndex);
                }
            }

            page.Controls.Add(panel);

            return page;
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Control changedControl = (Control)sender;
                Fight fight = tournament.GetFightByID((Guid)changedControl.Tag);

                if (changedControl.Name == "AResult")
                {
                    Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                    fight.fighterAResult = result;

                    Control[] ctrlsB = changedControl.Parent.Controls.Find("BResult", false);
                    ComboBox ddlB = (ComboBox)ctrlsB.Where(ct => (Guid)ct.Tag == fight.fightID).First();

                    if ((Fight.FightResult)ddlB.SelectedItem == Fight.FightResult.PENDING)
                    {
                        switch (result)
                        {
                            case Fight.FightResult.DRAW:
                                ddlB.SelectedItem = Fight.FightResult.DRAW;
                                break;

                            case Fight.FightResult.LOSS:
                                ddlB.SelectedItem = Fight.FightResult.WIN;
                                break;

                            case Fight.FightResult.WIN:
                                ddlB.SelectedItem = Fight.FightResult.LOSS;
                                break;
                        }
                    }
                }
                else if (changedControl.Name == "BResult")
                {
                    Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                    fight.fighterBResult = result;

                    Control[] ctrlsA = changedControl.Parent.Controls.Find("AResult", false);
                    ComboBox ddlA = (ComboBox)ctrlsA.Where(ct => (Guid)ct.Tag == fight.fightID).First();

                    if ((Fight.FightResult)ddlA.SelectedItem == Fight.FightResult.PENDING)
                    {
                        switch (result)
                        {
                            case Fight.FightResult.DRAW:
                                ddlA.SelectedItem = Fight.FightResult.DRAW;
                                break;

                            case Fight.FightResult.LOSS:
                                ddlA.SelectedItem = Fight.FightResult.WIN;
                                break;

                            case Fight.FightResult.WIN:
                                ddlA.SelectedItem = Fight.FightResult.LOSS;
                                break;
                        }
                    }
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

                    if (tournament.doubleThreshold != null && fight.doubleCount >= tournament.doubleThreshold)
                    {
                        Control[] ctrlsA = changedControl.Parent.Controls.Find("AResult", false);
                        Control[] ctrlsB = changedControl.Parent.Controls.Find("BResult", false);

                        ComboBox ddlA = (ComboBox)ctrlsA.Where(ct => (Guid)ct.Tag == fight.fightID).First();
                        ComboBox ddlB = (ComboBox)ctrlsB.Where(ct => (Guid)ct.Tag == fight.fightID).First();

                        fight.fighterAResult = Fight.FightResult.DQ;
                        ddlA.SelectedItem = Fight.FightResult.DQ;
                        fight.fighterBResult = Fight.FightResult.DQ;
                        ddlB.SelectedItem = Fight.FightResult.DQ;
                    }
                }

                //save changes
                FileAccessHelper.SaveTournament(tournament, FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving tournament - " + ex.Message);
                Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
            }

            LoadFighters();
        }

        private void btnManageFight_Click(object sender, EventArgs e)
        {
            Fight f = tournament.GetFightByID((Guid)((Button)sender).Tag);

            ManageFight dialog = new ManageFight(f, tournament, f.allowDraw, f.isFinal);
            dialog.FormClosed += Dialog_FormClosed;
            if(!dialog.IsDisposed)dialog.ShowDialog();
        }

        private void Dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManageFight dialog = (ManageFight)sender;

            if (dialog.ended)
            {
                Fight f = tournament.GetFightByID(dialog.fight.fightID);
                f.exchanges = dialog.fight.exchanges;
                f.SetResults(tournament);

                FileAccessHelper.SaveTournament(tournament, FilePath);
                LoadTournament();

                SelectLastPage();
            }
        }

        private void btnExtendPools_Click(object sender, EventArgs e)
        {
            if (tournament.IsComplete())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to generate another round of pool fights? This cannot be removed once added.", "Are you sure?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (tournament.ExtendPools())
                        {
                            FileAccessHelper.SaveTournament(tournament, FilePath);
                            LoadTournament();
                            SelectLastPage();
                        }
                        else
                        {
                            MessageBox.Show("Insufficient fighters per pool to generate a new round.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving tournament - " + ex.Message);
                        Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
                    }
                }
            }
            else
            {
                MessageBox.Show("Not all fights are complete!");
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

                try
                {
                    FileAccessHelper.SaveTournament(tournament, FilePath);
                    LoadTournament();
                    SelectLastPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving tournament - " + ex.Message);
                    Logging.WriteToLog("ErrorLog", ex.Message + " " + ex.StackTrace);
                }
            }
        }

        private void btnRatingsExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                FileAccessHelper.HEMARatingsExport(tournament, dialog.SelectedPath);

                System.Diagnostics.Process.Start(dialog.SelectedPath);
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                MergeResults mergeDialog = new MergeResults(tournament, FileAccessHelper.LoadTournament(dialog.FileName));
                mergeDialog.FormClosed += MergeDialog_Closed;
                if (!mergeDialog.IsDisposed) mergeDialog.ShowDialog();
            }
        }

        private void MergeDialog_Closed(object sender, EventArgs e)
        {
            MergeResults dialog = (MergeResults)sender;
            if (dialog.DialogResult == DialogResult.OK)
            {
                tournament.MergeFightResults(dialog.updates);
                FileAccessHelper.SaveTournament(tournament, FilePath);
            }

            LoadTournament();
            SelectLastPage();
        }
    }
}

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
                        foreach(var item in Enum.GetValues(typeof(Fight.FightResult))) { ddlResultA.Items.Add(item); }
                        ddlResultA.SelectedItem = fight.fighterAResult;
                        ddlResultA.SelectedValueChanged += control_ValueChanged;
                        if (tournament.stage != Tournament.TournamentStage.POOLFIGHTS) ddlResultA.Enabled = false;
                        panel.Controls.Add(ddlResultA, 1, rowIndex);

                        panel.Controls.Add(new Label() { Text =  " V " }, 2, rowIndex);

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
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            Control changedControl = (Control)sender;
            Fight fight = tournament.GetFightByID((Guid)changedControl.Tag);

            if(changedControl.Name == "AResult")
            {
                Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                fight.fighterAResult = result;
            }
            else if (changedControl.Name == "BResult")
            {
                Fight.FightResult result = (Fight.FightResult)((ComboBox)changedControl).SelectedItem;

                fight.fighterBResult = result;
            }
            else if(changedControl.Name == "DBLCount")
            {
                fight.doubleCount = (int)((NumericUpDown)changedControl).Value;
            }

            //save changes
            FileAccessHelper.SaveTournament(tournament, FilePath);

            LoadFighters();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwordJet
{
    public partial class MergeResults : Form
    {
        private Tournament firstTournament, secondTournament;
        public List<Fight> updates;

        public MergeResults(Tournament a, Tournament b)
        {
            InitializeComponent();

            if (!Tournament.DoTournamentsMatch(a, b))
            {
                MessageBox.Show("Loaded tournament files do not match, results cannot be merged");
                Close();
            }
            else
            {
                firstTournament = a;
                secondTournament = b;
                updates = new List<Fight>();

                LoadFightList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            updates.Clear();
            foreach(DataRow row in ((DataTable)dgvResults.DataSource).Rows)
            {
                if((bool)row["Merge?"] == true)
                {
                    Guid id = Guid.Parse(row["Fight ID"].ToString());
                    updates.Add(secondTournament.FindFight(id));
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public void LoadFightList()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Fight ID", typeof(string));
            table.Columns.Add("Fighter A", typeof(string));
            table.Columns.Add("Fighter B", typeof(string));
            table.Columns.Add("Pool", typeof(string));
            table.Columns.Add("Fighter A Result (First Tournament)", typeof(string));
            table.Columns.Add("Fighter B Result (First Tournament)", typeof(string));
            table.Columns.Add("Doubles (First Tournament)", typeof(string));
            table.Columns.Add("Fighter A Result (Second Tournament)", typeof(string));
            table.Columns.Add("Fighter B Result (Second Tournament)", typeof(string));
            table.Columns.Add("Doubles (Second Tournament)", typeof(string));
            table.Columns.Add("Merge?", typeof(bool));

            for(int i = 0; i < table.Columns.Count-1; i++)
            {
                table.Columns[i].ReadOnly = true;
            }

            for(int i = 0; i < firstTournament.pools.Count; i++)
            {
                Pool p = firstTournament.pools[i];
                for(int j = 0; j < p.rounds.Count; j++)
                {
                    List<Fight> round = p.rounds[j];

                    for(int k = 0; k < round.Count; k++)
                    {
                        Fight a = firstTournament.pools[i].rounds[j][k];
                        Fight b = secondTournament.pools[i].rounds[j][k];

                        if (a.fighterAResult != b.fighterAResult || a.fighterBResult != b.fighterBResult || a.doubleCount != b.doubleCount)
                        {
                            table.Rows.Add(GetFightDataRow(table,p,a,b));
                        }
                    }
                }
            }

            for(int i = 0; i < firstTournament.eliminations.Count; i++)
            {
                Pool p = firstTournament.eliminations[i];
                for (int j = 0; j < p.rounds.Count; j++)
                {
                    List<Fight> round = p.rounds[j];

                    for (int k = 0; k < round.Count; k++)
                    {
                        Fight a = firstTournament.eliminations[i].rounds[j][k];
                        Fight b = secondTournament.eliminations[i].rounds[j][k];

                        if (a.fighterAResult != b.fighterAResult || a.fighterBResult != b.fighterBResult || a.doubleCount != b.doubleCount)
                        {
                            table.Rows.Add(GetFightDataRow(table, p, a, b));
                        }
                    }
                }
            }

            if(firstTournament.tieBreakers != null)
            {
                Pool p = firstTournament.tieBreakers;
                for (int j = 0; j < p.rounds.Count; j++)
                {
                    List<Fight> round = p.rounds[j];

                    for (int k = 0; k < round.Count; k++)
                    {
                        Fight a = firstTournament.tieBreakers.rounds[j][k];
                        Fight b = secondTournament.tieBreakers.rounds[j][k];

                        if (a.fighterAResult != b.fighterAResult || a.fighterBResult != b.fighterBResult || a.doubleCount != b.doubleCount)
                        {
                            table.Rows.Add(GetFightDataRow(table, p, a, b));
                        }
                    }
                }
            }

            dgvResults.DataSource = table;
        }

        private DataRow GetFightDataRow(DataTable table, Pool p, Fight a, Fight b)
        {
            DataRow row = table.NewRow();

            row["Fight ID"] = a.fightID;
            row["Fighter A"] = firstTournament.GetFighterByID(a.fighterA).name;
            row["Fighter B"] = firstTournament.GetFighterByID(a.fighterB).name;
            row["Pool"] = p.name;
            row["Fighter A Result (First Tournament)"] = a.fighterAResult.ToString();
            row["Fighter B Result (First Tournament)"] = a.fighterBResult.ToString();
            row["Doubles (First Tournament)"] = a.doubleCount;
            row["Fighter A Result (Second Tournament)"] = b.fighterAResult.ToString();
            row["Fighter B Result (Second Tournament)"] = b.fighterBResult.ToString();
            row["Doubles (Second Tournament)"] = b.doubleCount;
            row["Merge?"] = (b.IsComplete());//true;

            return row;
        }
    }
}

using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace TournamentGenerator
{
    public partial class TournamentManager : Form
    {
        public TournamentManager()
        {
            InitializeComponent();

            int retryLimit = 50;
            int.TryParse(ConfigurationManager.AppSettings["fightGenerationRetryLimit"], out retryLimit);
            ConfigValues.fightGenerationRetryLimit = retryLimit;

            List<string> poolNames = new List<string>();
            poolNames.AddRange(ConfigurationManager.AppSettings["poolNames"].Split(','));
            ConfigValues.poolNames = poolNames;

            List<int> elimSizes = new List<int>();
            List<string> tempElimSizes = new List<string>();
            tempElimSizes.AddRange(ConfigurationManager.AppSettings["elimSizes"].Split(','));
            foreach(string str in tempElimSizes)
            {
                elimSizes.Add(int.Parse(str));
            }
            ConfigValues.eliminationSizes = elimSizes;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".sjt";
            dialog.FileName = "Tournament - " + DateTime.Today.ToString("dd MM yyyy");
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;
                try
                {
                    Tournament tournament = new Tournament();
                    FileAccessHelper.SaveTournament(tournament, path);

                    TournamentSetupForm tournForm = new TournamentSetupForm(path);
                    tournForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Tournament files|*.sjt";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;
                try
                {
                    Tournament tournament = FileAccessHelper.LoadTournament(path);

                    if(tournament != null)
                    { 
                        TournamentSetupForm tournForm = new TournamentSetupForm(path);
                        tournForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("File not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

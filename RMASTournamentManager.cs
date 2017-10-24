using System;
using System.Windows.Forms;

namespace TournamentGenerator
{
    public partial class RMASTournamentManager : Form
    {
        public RMASTournamentManager()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".rmas";
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
            dialog.Filter = "Tournament files|*.rmas";
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

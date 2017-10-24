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
            tournament = FileAccessHelper.LoadTournament(FilePath);
        }

        private void ManageTournament_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class EditClubs : Form
    {
        public  List<Club> clubList = new List<Club>();

        public EditClubs(List<Club> clubs)
        {
            InitializeComponent();

            ddlCountry.DataSource = Country.Countries;
            ddlCountry.SelectedItem = Country.Countries.Where(c => c.code == "GB").First();

            clubList = clubs;

            lbClubs.DataSource = clubList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                clubList.Add(new Club() { name = txtName.Text, city = txtCity.Text, country = ddlCountry.SelectedItem.ToString(), state = txtState.Text });
                lbClubs.DataSource = null;
                lbClubs.DataSource = clubList;

                txtName.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
            }
        }

        private void lbClubs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbClubs.SelectedItem != null)
            {
                Club club = (Club)lbClubs.SelectedItem;

                clubList.Remove(club);

                txtName.Text = club.name;
                txtCity.Text = club.city;
                txtState.Text = club.state;
                ddlCountry.SelectedItem = Country.Countries.Where(c => c.code == club.country);

                lbClubs.DataSource = null;
                lbClubs.DataSource = clubList;
            }
        }
    }
}

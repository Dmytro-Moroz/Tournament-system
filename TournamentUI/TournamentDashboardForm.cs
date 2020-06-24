using System.Collections.Generic;
using System.Windows.Forms;
using TournamentLibrary.Configuration;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connections.GetAllTournaments();

        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            LoadDropDownValue.DataSource = tournaments;
            LoadDropDownValue.DisplayMember = "TournamentName";
        }

        private void CreateTournamentButton_Click(object sender, System.EventArgs e)
        {
            CreateTournamentForm form = new CreateTournamentForm();
            form.Show();
        }

        private void LoadTournamentButton_Click(object sender, System.EventArgs e)
        {
            TournamentModel tournament = (TournamentModel) LoadDropDownValue.SelectedItem;
            TournamentViewForm tform = new TournamentViewForm(tournament);
            tform.Show();
        }
    }
}
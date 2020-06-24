using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.Configuration;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequestor
    {
        private List<TeamModel> availableTeams = GlobalConfig.Connections.GetAllTeams();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> prizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            SelectTeamDropDown.DataSource = null;
            SelectTeamDropDown.DataSource = availableTeams;
            SelectTeamDropDown.DisplayMember = "TeamName";

            TournamentTeamListbox.DataSource = null;
            TournamentTeamListbox.DataSource = selectedTeams;
            TournamentTeamListbox.DisplayMember = "TeamName";

            PrizesListBox.DataSource = null;
            PrizesListBox.DataSource = prizes;
            PrizesListBox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, System.EventArgs e)
        {
            TeamModel team = (TeamModel) SelectTeamDropDown.SelectedItem;
            if (team != null)
            {
                availableTeams.Remove(team);
                selectedTeams.Add(team);
                WireUpLists();
            }
        }

        private void CreatePrizeButton_Click(object sender, System.EventArgs e)
        {
            CreatePrizeForm cpf = new CreatePrizeForm(this);
            cpf.Show();
        }

        public void PrizeComplete(PrizeModel prize)
        {
            prizes.Add(prize);
            WireUpLists();
        }

        public void TeamComplete(TeamModel team)
        {
            selectedTeams.Add(team);
            WireUpLists();
        }

        private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamForm = new CreateTeamForm(this);
            teamForm.Show();
        }

        private void RemovePlayersButton_Click(object sender, System.EventArgs e)
        {
            TeamModel team = (TeamModel) TournamentTeamListbox.SelectedItem;
            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);
                WireUpLists();
            }
        }

        private void RemovePrizeButton_Click(object sender, System.EventArgs e)
        {
            PrizeModel prize = (PrizeModel) PrizesListBox.SelectedItem;
            if (prize != null)
            {
                prizes.Remove(prize);
                WireUpLists();
            }
        }

        private void CreateTournamentButton_Click(object sender, System.EventArgs e)
        {
            bool feeAcceptable = decimal.TryParse(EntryFeeValue.Text, out var fee);
            if (!feeAcceptable)
            {
                MessageBox.Show("Please enter rightly sum of fee", "Wrong fee entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TournamentModel tournament = new TournamentModel();
            tournament.TournamentName = TournamentNameValue.Text;
            tournament.EnrtyFee = fee;
            tournament.Prizes = prizes;
            tournament.EnteredTeams = selectedTeams;

            TournamentLogic.CreateRounds(tournament);

            GlobalConfig.Connections.CreateTournament(tournament);
            tournament.AlertUsersToNewRound();
            TournamentViewForm tform = new TournamentViewForm(tournament);
            tform.Show();
            this.Close();
        }
    }
}
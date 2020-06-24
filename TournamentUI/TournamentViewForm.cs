using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class TournamentViewForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;
            if (tournament != null)
            {
                tournament.CompleteTournament += Tournament_CompleteTournament;
            }
            LoadFormData();
            LoadRounds();
            WireUpLists();
        }

        private void Tournament_CompleteTournament(object sender, DateTime e)
        {
            this.Close();
        }

        private void LoadFormData()
        {
            TournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            RoundNumber.DataSource = rounds;
            MatchupListbox.DataSource = selectedMatchups;
            MatchupListbox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;

            if (tournament != null)
            {
                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    if (matchups.First().MatchupRound > currentRound)
                    {
                        currentRound = matchups.First().MatchupRound;
                        rounds.Add(currentRound);
                    }
                }
            }
            LoadMatchups(1);
        }

        private void RoundNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundNumber.SelectedItem);
        }

        private void LoadMatchups(int round)
        {
            if (tournament != null)
            {
                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    if (matchups.First().MatchupRound == round)
                    {
                        selectedMatchups.Clear();
                        foreach (MatchupModel m in matchups)
                        {
                            if (m.Winner == null || !UnplayedOnlyCheckbox.Checked)
                            {
                                selectedMatchups.Add(m);
                            }
                        }
                    }
                }
            }

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);
            TeamOneName.Visible = isVisible;
            TeamOneScoreLabel.Visible = isVisible;
            TeamOneScoreValue.Visible = isVisible;
            TeamTwoName.Visible = isVisible;
            TeamTwoScoreLabel.Visible = isVisible;
            TeamTwoScoreValue.Visible = isVisible;
            VersusLabel.Visible = isVisible;
            ScoreButton.Visible = isVisible;
        }

        private void MatchupListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)MatchupListbox.SelectedItem);
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                            TeamOneScoreValue.Text = m.Entries[0].Score.ToString();

                            TeamTwoName.Text = "<bye>";
                            TeamTwoScoreValue.Text = "0";
                        }
                        else
                        { 
                            TeamOneName.Text = @"Team not set yet";
                            TeamOneScoreValue.Text = "";
                        }
                    }
                    if (i == 1)
                    { if (m.Entries[1].TeamCompeting != null)
                        { 
                            TeamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                            TeamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                        }
                        else
                        { 
                            TeamTwoName.Text = @"Team not set yet"; 
                            TeamTwoScoreValue.Text = "";
                        }
                    }
                }
            }
        }

        private void UnplayedOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundNumber.SelectedItem);
        }

        private string ValidateData()
        {
            string output = "";
            int teamOneScore = 0;
            int teamTwoScore = 0;

            bool scoreOneValid = int.TryParse(TeamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = int.TryParse(TeamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The sore one value is not valid number";
            }
            else if (!scoreTwoValid)
            {
                output = "The sore two value is not valid number";
            }

            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "Please enter any score to any team";
            }

            else if (teamOneScore == teamTwoScore)
            {
                output = "No ties in this game!!!";
            }

            return output;
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            string errorMsg = ValidateData();
            if (errorMsg.Length > 0)
            {
                MessageBox.Show($"Input type Error: {errorMsg}");
                return;
            }
            MatchupModel mModel = (MatchupModel) MatchupListbox.SelectedItem;
            int teamOneScore = 0;
            int teamTwoScore = 0;

            for (int i = 0; i < mModel.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (mModel.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = int.TryParse(TeamOneScoreValue.Text, out teamOneScore);

                        if (scoreValid)
                        {
                            mModel.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score");
                            return;
                        }
                    }
                }
                if (i == 1)
                {
                    if (mModel.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = int.TryParse(TeamTwoScoreValue.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            mModel.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Occured Error: {exception.Message}");
                return;
            }
            LoadMatchups((int)RoundNumber.SelectedItem);
        }
    }
}

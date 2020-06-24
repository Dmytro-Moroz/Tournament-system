using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TournamentLibrary.Configuration;
using TournamentLibrary.Models;

namespace TournamentLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel tournament)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(tournament.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);
            tournament.Rounds.Add(CrateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(tournament, rounds);
        }

        private static List<MatchupModel> CrateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel currentModel = new MatchupModel();

            foreach (TeamModel t in teams)
            {
                currentModel.Entries.Add(new MatchupEntryModel{ TeamCompeting = t });
                if (byes > 0 || currentModel.Entries.Count > 1)
                {
                    currentModel.MatchupRound = 1;
                    output.Add(currentModel);
                    currentModel = new MatchupModel();
                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }

        private static void CreateOtherRounds(TournamentModel tournament, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = tournament.Rounds[0];
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();
            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel{ ParentMatchup = match});
                    if (currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }
                tournament.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound = new List<MatchupModel>();
                round += 1;
            }
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;
            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;
            return output;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int numOfRounds = 1;
            int value = 2;

            while (value < teamCount)
            {
                numOfRounds += 1;
                value *= 2;
            }

            return numOfRounds;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> team)
        {
            return team.OrderBy(item => Guid.NewGuid()).ToList();
        }

        private static void ScoreMatchupsLogic(List<MatchupModel> models)
        {
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];
            foreach (MatchupModel m in models)
            {
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }
                // 0/1 - false or true
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    } 
                    else if (m.Entries[1].Score < m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("No ties");
                    }
                }
                else
                {
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[1].Score > m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We plays without ties!!!");
                    }
                }
            }
        }

        private static void AdvanceWinner(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel mem in rm.Entries)
                        {
                            if (mem.ParentMatchup != null)
                            {
                                if (mem.ParentMatchup.Id == m.Id)
                                {
                                    mem.TeamCompeting = m.Winner;
                                    GlobalConfig.Connections.UpdateMatchup(rm);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel roundM in round)
                {
                    if (roundM.Winner == null && (roundM.Entries.Any(i => i.Score != 0) || roundM.Entries.Count == 1))
                    {
                        toScore.Add(roundM);
                    }
                }
            }

            ScoreMatchupsLogic(toScore);
            AdvanceWinner(toScore, model);
            toScore.ForEach(x => GlobalConfig.Connections.UpdateMatchup(x));
            int endingRound = model.CheckCurrentRound();

            if (endingRound > startingRound)
            {
                model.AlertUsersToNewRound();
            }
        }

        public static void AlertUsersToNewRound(this TournamentModel model)
        {
            int currRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currentRound = model.Rounds.First(i => i.First().MatchupRound == currRoundNumber);
            foreach (MatchupModel m in currentRound)
            {
                foreach (MatchupEntryModel mem in m.Entries)
                {
                    foreach (PersonModel person in mem.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(person, mem.TeamCompeting.TeamName, m.Entries.FirstOrDefault(i => i.TeamCompeting != mem.TeamCompeting));
                    }
                }
            }
        }

        private static void AlertPersonToNewRound(PersonModel person, string teamCompetingTeamName, MatchupEntryModel matchupEntryModel)
        {

            if (person.Email.Length == 0)
            {
                return;
            }

            string to = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            if (matchupEntryModel != null)
            {
                subject = $"You have a new matchup with opponent: { matchupEntryModel.TeamCompeting.TeamName }";

                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(matchupEntryModel.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a nice time!");
                body.AppendLine("~Tournament Application"); 
            }
            else
            {
                subject = "You have a bye week this round";

                body.AppendLine("Enjoy your round off");
                body.AppendLine("~Tournament Application");
            }

            to = person.Email;
            EmailLogic.SendEmail(to, subject, body.ToString());
        }

        private static int CheckCurrentRound(this TournamentModel tournament)
        {
            int result = 1;
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                if (round.All(i => i.Winner != null))
                {
                    result += 1;
                }
                else
                {
                    return result;
                }
            }

            CompleteTournament(tournament);
            return result - 1;
        }

        private static void CompleteTournament(TournamentModel tournament)
        {
            GlobalConfig.Connections.CompleteTournament(tournament);
            TeamModel winner = tournament.Rounds.Last().First().Winner;
            TeamModel looser = tournament.Rounds.Last().First().Entries.First(i => i.TeamCompeting != winner).TeamCompeting;

            decimal winnerPrize = 0;
            decimal looserPrize = 0;

            if (tournament.Prizes.Count > 0)
            {
                decimal totalIncome = tournament.EnteredTeams.Count * tournament.EnrtyFee;

                PrizeModel firstPlace = tournament.Prizes.FirstOrDefault(i => i.PlaceNumber == 1);
                PrizeModel secondPlace = tournament.Prizes.FirstOrDefault(i => i.PlaceNumber == 2);

                if (firstPlace != null)
                {
                    winnerPrize = firstPlace.CalculatePrize(totalIncome);
                }

                if (secondPlace != null)
                {
                    looserPrize = secondPlace.CalculatePrize(totalIncome);
                }
            }

            string subject = "";
            StringBuilder body = new StringBuilder();

            subject = $"In a tournament {tournament.TournamentName}, { winner.TeamName } is a winner.";

            body.AppendLine("<h1>Here is a winner!</h1>");
            body.Append("<p>Our Congrats! </p>");
            body.Append("<br />");
            if (winnerPrize > 0 )
            {
                body.Append($"<p>Winner {winner.TeamName}, receive {winnerPrize}</p>");
            }
            if (looserPrize > 0)
            {
                body.Append($"<p>Looser {looser.TeamName}, receive {looserPrize}</p>");
            }
            body.AppendLine("<p>Thanks for gaming. GoodBye!</p>");
            body.AppendLine("~Tournament Application");

            List<string> bcc = new List<string>();
            foreach (TeamModel team in tournament.EnteredTeams)
            {
                foreach (PersonModel person in team.TeamMembers)
                {
                    if (person.Email.Length > 0)
                    {
                        bcc.Add(person.Email);
                    }
                }
            }
            EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());
            tournament.TournamentComplete();
        }

        private static decimal CalculatePrize(this PrizeModel prize, decimal totalIncome)
        {
            decimal result = 0;

            if (prize.PrizeAmount > 0)
            {
                result = prize.PrizeAmount;
            }
            else
            {
                result = Decimal.Multiply(totalIncome,  Convert.ToDecimal(prize.PrizePercentage / 100));
            }

            return result;
        }
    }
}

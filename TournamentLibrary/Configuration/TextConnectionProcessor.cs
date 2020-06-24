using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TournamentLibrary.Models;

namespace TournamentLibrary.Configuration
{
    public static class TextConnectionProcessor
    {
        public static string FullFilePath(this string fileName)
        {

            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models)
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel person = new PersonModel();
                person.Id = int.Parse(cols[0]);
                person.FirstName = cols[1];
                person.LastName = cols[2];
                person.Email = cols[3];
                person.PhoneNumber = cols[4];
                output.Add(person);
            }

            return output;
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel team = new TeamModel();
                team.Id = int.Parse(cols[0]);
                team.TeamName = cols[1];
                string[] personsId = cols[2].Split('|');

                foreach (string id in personsId)
                {
                     team.TeamMembers.Add(people.First(i => i.Id == int.Parse(id)));
                }
                output.Add(team);
            }

            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines, string teamFileName, string peopleFileName, string prizesFileName)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> team = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchupModels = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TournamentModel tournament = new TournamentModel();
                tournament.Id = int.Parse(cols[0]);
                tournament.TournamentName = cols[1];
                tournament.EnrtyFee = decimal.Parse(cols[2]);

                string[] teamId = cols[3].Split('|');

                foreach (string id in teamId)
                {
                    tournament.EnteredTeams.Add(team.First(i => i.Id == int.Parse(id)));
                }

                if (cols[4].Length > 0)
                {
                    string[] prizeId = cols[4].Split('|');

                    foreach (string id in prizeId)
                    {
                        tournament.Prizes.Add(prizes.First(x => x.Id == int.Parse(id)));
                    }
                }

                //load rounds info
                string[] rounds = cols[5].Split('|');
                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();
                    foreach (string matchupModelTextId in msText)
                    {
                        ms.Add(matchupModels.First(i => i.Id == int.Parse(matchupModelTextId)));
                    }
                    tournament.Rounds.Add(ms);
                }

                output.Add(tournament);
            }

            return output;
        }

        public static void SaveToTeamFile(this List<TeamModel> team)
        {
            List<string> lines = new List<string>();
            foreach (TeamModel t in team)
            {
                lines.Add($"{t.Id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
            }
            File.WriteAllLines(GlobalConfig.TeamsFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> tournament)
        {
            List<string> lines = new List<string>();
            foreach (TournamentModel tr in tournament)
            {
                lines.Add($"{tr.Id},{tr.TournamentName},{tr.EnrtyFee},{ConvertTeamListToString(tr.EnteredTeams)},{ConvertPrizeListToString(tr.Prizes)},{ConvertRoundListToString(tr.Rounds) }");
            }
            File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
        }

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";
            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel team in teams)
            {
                output += $"{team.Id}|";
            }

            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel prize in prizes)
            {
                output += $"{prize.Id}|";
            }

            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            if (people.Count == 0)
            {
                return "";
            }
            foreach (PersonModel personModel in people)
            {
                output += $"{personModel.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<MatchupModel> round in rounds)
            {
                output += $"{ConvertMatchupListToString(round)}|";
            }

            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = "";
            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (MatchupModel matchup in matchups)
            {
                output += $"{matchup.Id}^";
            }

            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            string output = "";
            if (entries.Count == 0)
            {
                return "";
            }

            foreach (MatchupEntryModel entry in entries)
            {
                output += $"{entry.Id}|";
            }

            output = output.Substring(0, output.Length - 1);
            return output;
        }

        public static void SaveToPersonFile(this List<PersonModel> model)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel person in model)
            {
                lines.Add($"{person.Id},{person.FirstName},{person.LastName},{person.Email},{person.PhoneNumber}");
            }
            File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
        }

        public static void SaveRoundsToFile(this TournamentModel tournament)
        {
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel mm in round)
                {
                    mm.SaveMatchupToFile();
                }
            }
        }

        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupModel m = new MatchupModel();
                m.Id = int.Parse(cols[0]);
                m.Entries = ConvertStringToMatchupEntryModels(cols[1]);
                if (cols[2].Length == 0)
                {
                    m.Winner = null;
                }
                else
                {
                    m.Winner = FindTeamById(int.Parse(cols[2]));
                }
                m.MatchupRound = int.Parse(cols[3]);
                output.Add(m);
            }

            return output;
        }

        public static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();

            return output;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupEntryModel mem = new MatchupEntryModel();
                mem.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    mem.TeamCompeting = null;
                }
                else
                {
                    mem.TeamCompeting = FindTeamById(int.Parse(cols[1]));
                }
                
                mem.Score = int.Parse(cols[2]);

                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    mem.ParentMatchup = FindMatchupById(parentId);
                }
                else
                {
                    mem.ParentMatchup = null;
                }
                output.Add(mem);
            }
            return output;
        }

        private static MatchupModel FindMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();
            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchupToFind = new List<string>();
                    matchupToFind.Add(matchup);
                    return matchupToFind.ConvertToMatchupModels().First();
                }
            }

            return null;
        }

        public static TeamModel FindTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile();
            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels().First();
                }
            }

            return null;
        }

        public static void SaveMatchupToFile(this MatchupModel matchup)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 1;
            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(item => item.Id).First().Id + 1;
            }

            matchup.Id = currentId;
            // сохраняем запись 1 матча перед записью всех матчей
            matchups.Add(matchup);

            foreach (MatchupEntryModel entryModel in matchup.Entries)
            {
                entryModel.SaveEntryToFile();
            }

            List<string> lines = new List<string>();
            foreach (MatchupModel model in matchups)
            {
                string winner = "";
                if (model.Winner != null)
                {
                    winner = model.Winner.Id.ToString();
                }
                lines.Add($"{model.Id}, {ConvertMatchupEntryListToString(model.Entries)}, { winner }, {model.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(),lines);
        }

        public static void UpdateMatchupToFile(this MatchupModel matchup)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            MatchupModel oldMatchup = new MatchupModel();

            foreach (MatchupModel m in matchups)
            {
                if (m.Id == matchup.Id)
                {
                    oldMatchup = m;
                }
            }

            matchups.Remove(oldMatchup);

            // сохраняем запись 1 матча перед записью всех матчей
            matchups.Add(matchup);

            foreach (MatchupEntryModel entryModel in matchup.Entries)
            {
                entryModel.UpdateEntryToFile();
            }

            List<string> lines = new List<string>();
            foreach (MatchupModel model in matchups)
            {
                string winner = "";
                if (model.Winner != null)
                {
                    winner = model.Winner.Id.ToString();
                }
                lines.Add($"{model.Id}, {ConvertMatchupEntryListToString(model.Entries)}, { winner }, {model.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void UpdateEntryToFile(this MatchupEntryModel entry)
        {
            List<MatchupEntryModel> entryModels = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            MatchupEntryModel oldEntry = new MatchupEntryModel();

            foreach (MatchupEntryModel me in entryModels)
            {
                if (me.Id == entry.Id)
                {
                    oldEntry = me;
                }
            }

            entryModels.Remove(oldEntry);

            // add newest entries to a list
            entryModels.Add(entry);

            List<string> lines = new List<string>();
            foreach (MatchupEntryModel mem in entryModels)
            {
                string parent = "";
                if (mem.ParentMatchup != null)
                {
                    parent = mem.ParentMatchup.Id.ToString();
                }

                string teamCompeting = "";
                if (mem.TeamCompeting != null)
                {
                    teamCompeting = mem.TeamCompeting.Id.ToString();
                }
                lines.Add($"{mem.Id}, {teamCompeting}, {mem.Score}, {parent}");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }

        public static void SaveEntryToFile(this MatchupEntryModel entry)
        {
            List<MatchupEntryModel> entryModels = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentId = 1;
            if (entryModels.Count > 0)
            {
                currentId = entryModels.OrderByDescending(item => item.Id).First().Id + 1;
            }

            entry.Id = currentId;

            // add newest entries to a list
            entryModels.Add(entry);

            List<string> lines = new List<string>();
            foreach (MatchupEntryModel mem in entryModels)
            {
                string parent = "";
                if (mem.ParentMatchup != null)
                {
                    parent = mem.ParentMatchup.Id.ToString();
                }

                string teamCompeting = "";
                if (mem.TeamCompeting != null)
                {
                    teamCompeting = mem.TeamCompeting.Id.ToString();
                }
                lines.Add($"{mem.Id}, {teamCompeting}, {mem.Score}, {parent}");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }
    }
}
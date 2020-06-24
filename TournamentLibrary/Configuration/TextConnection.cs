using System.Collections.Generic;
using System.Linq;
using TournamentLibrary.Models;

namespace TournamentLibrary.Configuration
{
    public class TextConnection : IDataConnection
    {
        public void CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;
            if (prizes.Count > 0)
            {
               currentId = prizes.OrderByDescending(item => item.Id).First().Id + 1;
            }

            model.Id = currentId;
            prizes.Add(model);

            prizes.SaveToPrizeFile();
        }

        public void CreatePerson(PersonModel person)
        {
            List<PersonModel> persons = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;
            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(p => p.Id).First().Id + 1;
            }

            person.Id = currentId;
            persons.Add(person);
            persons.SaveToPersonFile();
        }

        public void CreateTeam(TeamModel team)
        {
            List<TeamModel> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(p => p.Id).First().Id + 1;
            }

            team.Id = currentId;
            teams.Add(team);
            teams.SaveToTeamFile();
        }

        public List<PersonModel> GetAllPersons()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetAllTeams()
        {
            return GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public void CreateTournament(TournamentModel tournament)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(GlobalConfig.TournamentFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);

            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(p => p.Id).First().Id + 1;
            }

            tournament.Id = currentId;
            tournament.SaveRoundsToFile();
            tournaments.Add(tournament);
            tournaments.SaveToTournamentFile();
            TournamentLogic.UpdateTournamentResults(tournament);
        }

        public List<TournamentModel> GetAllTournaments()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(GlobalConfig.TournamentFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);
        }

        public void CompleteTournament(TournamentModel tournament)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(GlobalConfig.TournamentFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);

            tournaments.Remove(tournament);
            tournaments.SaveToTournamentFile();
            TournamentLogic.UpdateTournamentResults(tournament);
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
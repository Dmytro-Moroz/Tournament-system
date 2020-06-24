using System.Collections.Generic;
using TournamentLibrary.Models;

namespace TournamentLibrary.Configuration
{
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel model);
        void CreatePerson(PersonModel person);
        void CreateTeam(TeamModel team);
        List<PersonModel> GetAllPersons();
        List<TeamModel> GetAllTeams();
        void CreateTournament(TournamentModel tournament);
        void UpdateMatchup(MatchupModel model);
        List<TournamentModel> GetAllTournaments();
        void CompleteTournament(TournamentModel tournament);
    }
}

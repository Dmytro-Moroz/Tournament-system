using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournamentLibrary.Models;

namespace TournamentLibrary.Configuration
{
    public class SQLConnection : IDataConnection
    {
        private const string dbName = "Tournaments";

        public void CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        public void CreatePerson(PersonModel person)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", person.FirstName);
                p.Add("@LastName", person.LastName);
                p.Add("@Email", person.Email);
                p.Add("@PhoneNumber", person.PhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);
                person.Id = p.Get<int>("@id");
            }
        }

        public void CreateTeam(TeamModel team)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                var t = new DynamicParameters();
                t.Add("Id", 0, dbType: DbType.Int32, direction:ParameterDirection.InputOutput);
                t.Add("@TeamName", team.TeamName);

                connection.Execute("dbo.spTeams_Insert", t, commandType: CommandType.StoredProcedure);
                team.Id = t.Get<int>("@Id");

                foreach (PersonModel teamMember in team.TeamMembers)
                {
                    t = new DynamicParameters();
                    t.Add("TeamId", team.Id);
                    t.Add("PersonId", teamMember.Id);
                    connection.Execute("dbo.spTeamMembers_Insert", t, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public void CreateTournament(TournamentModel tournament)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                SaveTournament(connection ,tournament);
                SaveTournamentPrizes(connection, tournament);
                SaveTournamentTeams(connection, tournament);
                SaveTournamentsRounds(connection, tournament);
                TournamentLogic.UpdateTournamentResults(tournament);
            }
        }

        public void UpdateMatchup(MatchupModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                var upd = new DynamicParameters();
                if (model.Winner != null)
                {
                    upd.Add("@Id", model.Id);
                    upd.Add("@WinnerId", model.Winner.Id);

                    connection.Execute("dbo.spMatchups_Update", upd, commandType: CommandType.StoredProcedure);
                }

                // dbo.spMatchupEntries_Update @Id, @TeamCompetingId, @Score
                foreach (MatchupEntryModel entry in model.Entries)
                {
                    if (entry.TeamCompeting != null)
                    {
                        upd = new DynamicParameters();
                        upd.Add("@Id", entry.Id);
                        upd.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        upd.Add("@Score", entry.Score);

                        connection.Execute("dbo.spMatchupEntries_Update", upd, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public List<TournamentModel> GetAllTournaments()
        {
            List<TournamentModel> output;
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                output = connection.Query<TournamentModel>("dbo.spTournaments_GetAll").ToList();
                var p = new DynamicParameters();

                foreach (TournamentModel t in output)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.Prizes = connection.Query<PrizeModel>("dbo.spPrizes_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    t.EnteredTeams = connection.Query<TeamModel>("dbo.spTeam_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (TeamModel team in t.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamId", team.Id);
                        team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("spMatchups_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (MatchupModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);
                        m.Entries = connection.Query<MatchupEntryModel>("dbo.spMatchupEntries_GetByMatchup", p, commandType: CommandType.StoredProcedure).ToList();

                        // populate each entry (2 models)
                        // populate each matchup (1 models)
                        List<TeamModel> allTeams = GetAllTeams();
                        if (m.WinnerId > 0)
                        {
                            m.Winner = allTeams.First(i => i.Id == m.WinnerId);
                        }
                        foreach (var me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.TeamCompeting = allTeams.First(item => item.Id == me.TeamCompetingId);
                            }

                            if (me.ParentMatchupId > 0)
                            {
                                me.ParentMatchup = matchups.First(i => i.Id == me.ParentMatchupId);
                            }
                        }
                    }

                    // List<List<MatchupModel>>
                    List<MatchupModel> currentRow = new List<MatchupModel>(); // round info
                    int currentRound = 1;

                    foreach (MatchupModel m in matchups)
                    {
                        if (m.MatchupRound > currentRound)
                        {
                            t.Rounds.Add(currentRow);
                            currentRow = new List<MatchupModel>();
                            currentRound += 1;
                        }
                        currentRow.Add(m);
                    }
                    t.Rounds.Add(currentRow);
                }
            }
            return output;
        }

        public void CompleteTournament(TournamentModel tournament)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                var upd = new DynamicParameters();
                upd.Add("@Id", tournament.Id);

                connection.Execute("spTournaments_Complete", upd, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournament(IDbConnection connection, TournamentModel tournament)
        {
            var trnm = new DynamicParameters();
            trnm.Add("@TournamentName", tournament.TournamentName);
            trnm.Add("@EntryFee", tournament.EnrtyFee);
            trnm.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", trnm, commandType: CommandType.StoredProcedure);
            tournament.Id = trnm.Get<int>("@Id");
        }

        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel tournament)
        {
            foreach (PrizeModel prize in tournament.Prizes)
            {
                var trnm = new DynamicParameters();
                trnm.Add("@TournamentId", tournament.Id);
                trnm.Add("@PrizeId", prize.Id);
                trnm.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentPrizes_Insert", trnm, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentTeams(IDbConnection connection, TournamentModel tournament)
        {
            foreach (TeamModel team in tournament.EnteredTeams)
            {
                var trnm = new DynamicParameters();
                trnm.Add("@TournamentId", tournament.Id);
                trnm.Add("@TeamId", team.Id);
                trnm.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.TournamentTeams_Insert", trnm, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentsRounds(IDbConnection connection, TournamentModel tournament)
        {
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    var x = new DynamicParameters();
                    x.Add("@TournamentId", tournament.Id);
                    x.Add("@MatchupRound", matchup.MatchupRound);
                    x.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spMatchups_Insert", x, commandType: CommandType.StoredProcedure);
                    matchup.Id = x.Get<int>("@Id");

                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                        x = new DynamicParameters();
                        x.Add("@MatchupId", matchup.Id);
                        if (entry.ParentMatchup == null)
                        {
                            x.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            x.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                        }

                        if (entry.TeamCompeting == null)
                        {
                            x.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            x.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        }
                        x.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spMatchupEntries_Insert", x, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public List<PersonModel> GetAllPersons()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }
            return output;
        }

        public List<TeamModel> GetAllTeams()
        {
            List<TeamModel> output;
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(dbName)))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();
                foreach (TeamModel team in output)
                {
                    var t = new DynamicParameters();
                    t.Add("TeamId", team.Id);
                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", t, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }
    }
}
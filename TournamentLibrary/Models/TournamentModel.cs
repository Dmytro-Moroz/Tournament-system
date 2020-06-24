using System;
using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public decimal EnrtyFee { get; set; }
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

        public event EventHandler<DateTime> CompleteTournament;

        public void TournamentComplete()
        {
            CompleteTournament?.Invoke(this, DateTime.Now);
        }
    }
}
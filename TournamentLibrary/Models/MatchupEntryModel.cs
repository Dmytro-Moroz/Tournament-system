namespace TournamentLibrary.Models
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// Represents one Team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Score for team
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Represents the matchup that this team came from as a winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
        public int ParentMatchupId { get; set; }
    }
}
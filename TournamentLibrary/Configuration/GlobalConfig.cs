using System.Collections.Generic;
using System.Configuration;

namespace TournamentLibrary.Configuration
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamsFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";

        public static IDataConnection Connections { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {

            if (db == DatabaseType.Sql)
            {
                SQLConnection sql = new SQLConnection();
                Connections = sql;
            }

            else if (db == DatabaseType.TextFile)
            {
                TextConnection textConnection = new TextConnection();
                Connections = textConnection;
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
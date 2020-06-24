using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentLibrary;

namespace TournamentUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize
            TournamentLibrary.Configuration.GlobalConfig.InitializeConnections(DatabaseType.Sql);
            //Application.Run(new CreatePrizeForm());
            Application.Run(new TournamentDashboardForm());
            //Application.Run(new CreateTournamentForm());
            //Application.Run(new CreateTeamForm());
        }
    }
}
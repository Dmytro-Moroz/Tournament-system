using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public interface ITeamRequestor
    {
        void TeamComplete(TeamModel team);
    }
}

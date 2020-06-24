using TournamentLibrary.Models;

namespace TournamentUI
{
    public interface IPrizeRequester
    {
        void PrizeComplete(PrizeModel prize);
    }
}

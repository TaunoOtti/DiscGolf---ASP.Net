using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IScoreRepository : IEFRepository<Score>
    {
        int GetScoreForPlayerGame(int gameId, int playerId, int totalPars);
        List<Score> GetScoresForGame(int gameId);
    }
}

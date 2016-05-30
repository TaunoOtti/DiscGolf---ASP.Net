using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ScoreRepository : EFRepository<Score>, IScoreRepository
    {
        public ScoreRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public int GetScoreForPlayerGame(int gameId, int playerInGameId, int totalPars)
        {
            var res = DbSet.Where(x => x.GameId == gameId && x.PlayerInGameId == playerInGameId).ToList();
            if (res.Count != 0) return (res.Sum(scr => scr.Throws) - totalPars);
            return 0;
            
        }

        public List<Score> GetScoresForGame(int gameId)
        {
            return DbSet.Where(x => x.GameId == gameId).ToList();
        }
    }
}

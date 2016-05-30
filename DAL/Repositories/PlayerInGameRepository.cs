using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;
using Domain.Identity;

namespace DAL.Repositories
{
    public class PlayerInGameRepository : EFRepository<PlayerInGame>, IPlayerInGameRepository
    {
        public PlayerInGameRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public PlayerInGame getPlayerInGameId(int game, int usr)
        {
            return DbSet.FirstOrDefault(x => x.GameId == game && x.UserId == usr);
        }

        public List<UserInt> GetAllUsersInGames(int? gameId)
        {
            List<PlayerInGame> asd = DbSet.Where(x => x.GameId == gameId).ToList();
            List<UserInt> playerIds = new List<UserInt>();
            foreach (var a in asd)
            {
                playerIds.Add(a.User);
            }
            return playerIds;
        }

        public int GetPlayerInGameId(int gameId, int userId)
        {
            return DbSet.FirstOrDefault(x => x.GameId == gameId && x.UserId == userId).PlayerInGameId;
        }

     

        public List<int> GetPlayerGames(int? userId)
        {
           List<int> GamesIds = new List<int>();
           var PlayerInGames = DbSet.Where(x => x.UserId == userId);
            foreach (var game in PlayerInGames)
            {
                GamesIds.Add(game.GameId);
            }
            return GamesIds;
        }
    }
}

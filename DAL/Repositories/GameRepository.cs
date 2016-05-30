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
    public class GameRepository : EFRepository<Game>, IGameRepository
    {
        public GameRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Game> GetAllGamesForUser(List<int> list)
        {
            
            return list.Select(Id => DbSet.FirstOrDefault(x => x.GameId == Id)).ToList();
        }

        //public List<Game> GetAllGamesToUser(int id)
        //{
        //    return DbSet.Where(x => x)
        //} 
    }
}

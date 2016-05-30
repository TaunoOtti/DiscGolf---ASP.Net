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
    public class PlayerRepository : EFRepository<Player>
    {
        public PlayerRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        //public List<Player> GetAllForUser(int userId)
        //{
        //    return DbSet.Where(p => p. == userId).OrderBy(o => o.Firstname).Include(o => o.PlayerInGames).ToList();
        //}

        //public Player GetForUser(int personId, int userId)
        //{
        //    return DbSet.FirstOrDefault(a => a.PlayerId == personId && a.UserId == userId);
        //}
    }
}

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
    public class BasketRepository : EFRepository<Basket>, IBasketRepository
    {
        public BasketRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Basket> AllforBasket(int basketId)
        {
            return null;
        }

        public List<Basket> GetAllBasketsForTrack(int? trackId)
        {
            return DbSet.Where(x => x.TrackId == trackId).ToList();
        }

        public int GetTotalParsForTrak(int trackId)
        {
            var res = DbSet.Where(x => x.TrackId == trackId).ToList();

            return res.Sum(bsk => bsk.Pars);
        }

        public int GetTotalBasketCount(int trackId)
        {
            return DbSet.Count(y => y.TrackId == trackId);
        }
    }
}

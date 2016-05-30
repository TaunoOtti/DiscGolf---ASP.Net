using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IBasketRepository : IEFRepository<Basket>
    {
        List<Basket> GetAllBasketsForTrack(int? trackId);

        int GetTotalParsForTrak(int trackId);
        int GetTotalBasketCount(int trackId);

    }
}

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
    public class TrackRepository : EFRepository<Track>, ITrackRepository
    {
        public TrackRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public Track GetTrackByGameId(int id)
        {
            return DbSet.FirstOrDefault(x => x.TrackId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IPlayerRepository : IEFRepository<Player>
    {
        /// <summary>
        /// Get all Persons for this user id
        /// </summary>
        /// <param name="userId">user ID to filter by</param>
        /// <returns>List of persons, belonging to this user id</returns>
        List<Player> GetAllForUser(int userId);

        Player GetForUser(int personId, int userId);
    }
}

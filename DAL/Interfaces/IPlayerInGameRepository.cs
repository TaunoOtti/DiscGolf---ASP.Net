using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Identity;

namespace DAL.Interfaces
{
    public interface IPlayerInGameRepository :IEFRepository<PlayerInGame>
    {
        List<UserInt> GetAllUsersInGames(int? gameId);

        int GetPlayerInGameId(int gameId, int userId);

        List<int> GetPlayerGames(int? userId);
    }
}

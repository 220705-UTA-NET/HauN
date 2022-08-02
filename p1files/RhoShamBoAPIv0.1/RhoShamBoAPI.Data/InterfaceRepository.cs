using RhoShamBoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhoShamBoAPI.Data
{
    public interface InterfaceRepository
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player> InsertPlayerAsync(string name, string city, string email);
        Task<IEnumerable<Tourney>> GetAllTourneysAsync();
    }
}

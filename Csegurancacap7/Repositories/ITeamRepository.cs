using Csegurancacap7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
    }
}

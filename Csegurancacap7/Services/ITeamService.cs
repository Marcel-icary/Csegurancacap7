using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamViewModel>> GetAllTeamsAsync();
        Task<TeamViewModel?> GetTeamByIdAsync(int id);
        Task AddTeamAsync(TeamViewModel teamViewModel);
        Task UpdateTeamAsync(TeamViewModel teamViewModel);
        Task DeleteTeamAsync(int id);
    }
}

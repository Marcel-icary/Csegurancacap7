using Csegurancacap7.Models;
using Csegurancacap7.Repositories;
using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamViewModel>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            return teams.Select(team => new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Quantity = team.Quantity,
                Specialty = team.Specialty,
                Availability = team.Availability,
                ZoneId = team.ZoneId
            });
        }

        public async Task<TeamViewModel?> GetTeamByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                return null;
            }

            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Quantity = team.Quantity,
                Specialty = team.Specialty,
                Availability = team.Availability,
                ZoneId = team.ZoneId
            };
        }

        public async Task AddTeamAsync(TeamViewModel teamViewModel)
        {
            var team = new Team
            {
                Name = teamViewModel.Name,
                Quantity = teamViewModel.Quantity,
                Specialty = teamViewModel.Specialty,
                Availability = teamViewModel.Availability,
                ZoneId = teamViewModel.ZoneId
            };
            await _teamRepository.AddAsync(team);
        }

        public async Task UpdateTeamAsync(TeamViewModel teamViewModel)
        {
            var team = new Team
            {
                Id = teamViewModel.Id,
                Name = teamViewModel.Name,
                Quantity = teamViewModel.Quantity,
                Specialty = teamViewModel.Specialty,
                Availability = teamViewModel.Availability,
                ZoneId = teamViewModel.ZoneId
            };
            await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
        }
    }
}

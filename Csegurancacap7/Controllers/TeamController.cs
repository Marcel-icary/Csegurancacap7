using Csegurancacap7.Services;
using Csegurancacap7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamViewModel>> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult> PostTeam(TeamViewModel teamViewModel)
        {
            await _teamService.AddTeamAsync(teamViewModel);
            return CreatedAtAction(nameof(GetTeam), new { id = teamViewModel.Id }, teamViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamViewModel teamViewModel)
        {
            if (id != teamViewModel.Id)
            {
                return BadRequest();
            }

            await _teamService.UpdateTeamAsync(teamViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}

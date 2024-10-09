using Csegurancacap7.Services;
using Csegurancacap7.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Adicionar autorização ao controlador
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> PostUser(UserViewModel userViewModel)
        {
            await _userService.AddUserAsync(userViewModel);
            return CreatedAtAction(nameof(GetUser), new { id = userViewModel.Id }, userViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(userViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}

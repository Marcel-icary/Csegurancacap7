using Csegurancacap7.Models;
using Csegurancacap7.Repositories;
using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = user.CreatedAt
            });
        }

        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task AddUserAsync(UserViewModel userViewModel)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                PhoneNumber = userViewModel.PhoneNumber,
                CreatedAt = userViewModel.CreatedAt
            };
            await _userRepository.AddAsync(user);
            userViewModel.Id = user.Id;
        }

        public async Task UpdateUserAsync(UserViewModel userViewModel)
        {
            var user = new User
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                PhoneNumber = userViewModel.PhoneNumber,
                CreatedAt = userViewModel.CreatedAt
            };
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}

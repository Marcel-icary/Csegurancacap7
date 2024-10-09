using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(int id); // Ajuste para permitir valores nulos
        Task AddUserAsync(UserViewModel userViewModel);
        Task UpdateUserAsync(UserViewModel userViewModel);
        Task DeleteUserAsync(int id);
    }
}

using Csegurancacap7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Repositories
{
    public interface ISORepository
    {
        Task<IEnumerable<SO>> GetAllAsync();
        Task<SO?> GetByIdAsync(int id);
        Task AddAsync(SO so);
        Task UpdateAsync(SO so);
        Task DeleteAsync(int id);
    }
}

using Csegurancacap7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Repositories
{
    public interface IOcorrenciaRepository
    {
        Task<IEnumerable<Ocorrencia>> GetAllAsync();
        Task<Ocorrencia?> GetByIdAsync(int id);
        Task AddAsync(Ocorrencia ocorrencia);
        Task UpdateAsync(Ocorrencia ocorrencia);
        Task DeleteAsync(int id);
    }
}

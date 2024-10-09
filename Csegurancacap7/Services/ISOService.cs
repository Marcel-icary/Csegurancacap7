using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public interface ISOService
    {
        // Método para obter todas as solicitações de ocorrência
        Task<IEnumerable<SOViewModel>> GetAllAsync();

        // Método para obter uma solicitação de ocorrência específica por ID
        Task<SOViewModel?> GetByIdAsync(int id);

        // Método para adicionar uma nova solicitação de ocorrência
        Task AddAsync(SOViewModel soViewModel);

        // Método para atualizar uma solicitação de ocorrência existente
        Task UpdateAsync(SOViewModel soViewModel);

        // Método para deletar uma solicitação de ocorrência existente
        Task DeleteAsync(int id);
    }
}

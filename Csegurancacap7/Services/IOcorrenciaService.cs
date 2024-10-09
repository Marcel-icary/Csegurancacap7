using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public interface IOcorrenciaService
    {
        // Método para obter todas as ocorrências
        Task<IEnumerable<OcorrenciaViewModel>> GetAllOcorrenciasAsync();

        // Método para obter uma ocorrência específica por ID
        Task<OcorrenciaViewModel?> GetOcorrenciaByIdAsync(int id);

        // Método para adicionar uma nova ocorrência
        Task AddOcorrenciaAsync(OcorrenciaViewModel ocorrenciaViewModel);

        // Método para atualizar uma ocorrência existente
        Task UpdateOcorrenciaAsync(OcorrenciaViewModel ocorrenciaViewModel);

        // Método para deletar uma ocorrência existente
        Task DeleteOcorrenciaAsync(int id);
    }
}

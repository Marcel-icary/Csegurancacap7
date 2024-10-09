using Csegurancacap7.Models;
using Csegurancacap7.Repositories;
using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        // Construtor do serviço que injeta o repositório de ocorrências
        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        // Método para obter todas as ocorrências
        public async Task<IEnumerable<OcorrenciaViewModel>> GetAllOcorrenciasAsync()
        {
            var ocorrencias = await _ocorrenciaRepository.GetAllAsync();
            return ocorrencias.Select(o => new OcorrenciaViewModel
            {
                Id = o.Id,
                SOId = o.SOId,
                Status = o.Status,
                ZoneId = o.ZoneId,
                TeamId = o.TeamId,
                ServiceDate = o.ServiceDate,
                EndDate = o.EndDate,
                Resolved = o.Resolved == 1, // Converte int para bool
                Observation = o.Observation
            });
        }

        // Método para obter uma ocorrência específica por ID
        public async Task<OcorrenciaViewModel?> GetOcorrenciaByIdAsync(int id)
        {
            var ocorrencia = await _ocorrenciaRepository.GetByIdAsync(id);
            if (ocorrencia == null)
            {
                return null;
            }

            return new OcorrenciaViewModel
            {
                Id = ocorrencia.Id,
                SOId = ocorrencia.SOId,
                Status = ocorrencia.Status,
                ZoneId = ocorrencia.ZoneId,
                TeamId = ocorrencia.TeamId,
                ServiceDate = ocorrencia.ServiceDate,
                EndDate = ocorrencia.EndDate,
                Resolved = ocorrencia.Resolved == 1, // Converte int para bool
                Observation = ocorrencia.Observation
            };
        }

        // Método para adicionar uma nova ocorrência
        public async Task AddOcorrenciaAsync(OcorrenciaViewModel ocorrenciaViewModel)
        {
            var ocorrencia = new Ocorrencia
            {
                SOId = ocorrenciaViewModel.SOId,
                Status = ocorrenciaViewModel.Status,
                ZoneId = ocorrenciaViewModel.ZoneId,
                TeamId = ocorrenciaViewModel.TeamId,
                ServiceDate = ocorrenciaViewModel.ServiceDate,
                EndDate = ocorrenciaViewModel.EndDate,
                Resolved = ocorrenciaViewModel.Resolved ? 1 : 0, // Converte bool para int
                Observation = ocorrenciaViewModel.Observation
            };
            await _ocorrenciaRepository.AddAsync(ocorrencia);
        }

        // Método para atualizar uma ocorrência existente
        public async Task UpdateOcorrenciaAsync(OcorrenciaViewModel ocorrenciaViewModel)
        {
            var ocorrencia = new Ocorrencia
            {
                Id = ocorrenciaViewModel.Id,
                SOId = ocorrenciaViewModel.SOId,
                Status = ocorrenciaViewModel.Status,
                ZoneId = ocorrenciaViewModel.ZoneId,
                TeamId = ocorrenciaViewModel.TeamId,
                ServiceDate = ocorrenciaViewModel.ServiceDate,
                EndDate = ocorrenciaViewModel.EndDate,
                Resolved = ocorrenciaViewModel.Resolved ? 1 : 0, // Converte bool para int
                Observation = ocorrenciaViewModel.Observation
            };
            await _ocorrenciaRepository.UpdateAsync(ocorrencia);
        }

        // Método para deletar uma ocorrência existente
        public async Task DeleteOcorrenciaAsync(int id)
        {
            await _ocorrenciaRepository.DeleteAsync(id);
        }
    }
}

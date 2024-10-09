using Csegurancacap7.Models;
using Csegurancacap7.Repositories;
using Csegurancacap7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csegurancacap7.Services
{
    public class SOService : ISOService
    {
        private readonly ISORepository _soRepository;

        // Construtor do serviço que injeta o repositório de solicitações de ocorrência
        public SOService(ISORepository soRepository)
        {
            _soRepository = soRepository;
        }

        // Método para obter todas as solicitações de ocorrência
        public async Task<IEnumerable<SOViewModel>> GetAllAsync()
        {
            var sos = await _soRepository.GetAllAsync();
            return sos.Select(so => new SOViewModel
            {
                Id = so.Id,
                UserId = so.UserId,
                Type = so.Type,
                Description = so.Description,
                ZoneId = so.ZoneId,
                FactDate = so.FactDate,
                Hour = so.Hour
            });
        }

        // Método para obter uma solicitação de ocorrência específica por ID
        public async Task<SOViewModel?> GetByIdAsync(int id)
        {
            var so = await _soRepository.GetByIdAsync(id);
            if (so == null)
            {
                return null;
            }

            return new SOViewModel
            {
                Id = so.Id,
                UserId = so.UserId,
                Type = so.Type,
                Description = so.Description,
                ZoneId = so.ZoneId,
                FactDate = so.FactDate,
                Hour = so.Hour
            };
        }

        // Método para adicionar uma nova solicitação de ocorrência
        public async Task AddAsync(SOViewModel soViewModel)
        {
            var so = new SO
            {
                UserId = soViewModel.UserId,
                Type = soViewModel.Type,
                Description = soViewModel.Description,
                ZoneId = soViewModel.ZoneId,
                FactDate = soViewModel.FactDate,
                Hour = soViewModel.Hour
            };
            await _soRepository.AddAsync(so);
        }

        // Método para atualizar uma solicitação de ocorrência existente
        public async Task UpdateAsync(SOViewModel soViewModel)
        {
            var so = new SO
            {
                Id = soViewModel.Id,
                UserId = soViewModel.UserId,
                Type = soViewModel.Type,
                Description = soViewModel.Description,
                ZoneId = soViewModel.ZoneId,
                FactDate = soViewModel.FactDate,
                Hour = soViewModel.Hour
            };
            await _soRepository.UpdateAsync(so);
        }

        // Método para deletar uma solicitação de ocorrência existente
        public async Task DeleteAsync(int id)
        {
            await _soRepository.DeleteAsync(id);
        }
    }
}

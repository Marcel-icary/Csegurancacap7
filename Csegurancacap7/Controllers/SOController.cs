using Csegurancacap7.Services;
using Csegurancacap7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SOController : ControllerBase
    {
        private readonly ISOService _soService;

        // Construtor do controlador que injeta o serviço de solicitações de ocorrências
        public SOController(ISOService soService)
        {
            _soService = soService;
        }

        // Endpoint para obter todas as solicitações de ocorrências
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SOViewModel>>> GetSOs()
        {
            var sos = await _soService.GetAllAsync();
            return Ok(sos); // Retorna a lista de solicitações de ocorrências com status 200 (OK)
        }

        // Endpoint para obter uma solicitação de ocorrência específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SOViewModel>> GetSO(int id)
        {
            var so = await _soService.GetByIdAsync(id);
            if (so == null)
            {
                return NotFound(); // Retorna status 404 (Not Found) se a solicitação de ocorrência não for encontrada
            }

            return Ok(so); // Retorna a solicitação de ocorrência encontrada com status 200 (OK)
        }

        // Endpoint para criar uma nova solicitação de ocorrência
        [HttpPost]
        public async Task<ActionResult> PostSO(SOViewModel soViewModel)
        {
            await _soService.AddAsync(soViewModel);
            // Retorna status 201 (Created) com a localização da nova solicitação de ocorrência criada
            return CreatedAtAction(nameof(GetSO), new { id = soViewModel.Id }, soViewModel);
        }

        // Endpoint para atualizar uma solicitação de ocorrência existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSO(int id, SOViewModel soViewModel)
        {
            if (id != soViewModel.Id)
            {
                return BadRequest(); // Retorna status 400 (Bad Request) se os IDs não coincidirem
            }

            await _soService.UpdateAsync(soViewModel);
            return NoContent(); // Retorna status 204 (No Content) após a atualização bem-sucedida
        }

        // Endpoint para deletar uma solicitação de ocorrência existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSO(int id)
        {
            await _soService.DeleteAsync(id);
            return NoContent(); // Retorna status 204 (No Content) após a exclusão bem-sucedida
        }
    }
}

using Csegurancacap7.Services;
using Csegurancacap7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;

        // Construtor do controlador que injeta o serviço de ocorrências
        public OcorrenciaController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        // Endpoint para obter todas as ocorrências
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> GetOcorrencias()
        {
            var ocorrencias = await _ocorrenciaService.GetAllOcorrenciasAsync();
            return Ok(ocorrencias); // Retorna a lista de ocorrências com status 200 (OK)
        }

        // Endpoint para obter uma ocorrência específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OcorrenciaViewModel>> GetOcorrencia(int id)
        {
            var ocorrencia = await _ocorrenciaService.GetOcorrenciaByIdAsync(id);
            if (ocorrencia == null)
            {
                return NotFound(); // Retorna status 404 (Not Found) se a ocorrência não for encontrada
            }

            return Ok(ocorrencia); // Retorna a ocorrência encontrada com status 200 (OK)
        }

        // Endpoint para criar uma nova ocorrência
        [HttpPost]
        public async Task<ActionResult> PostOcorrencia(OcorrenciaViewModel ocorrenciaViewModel)
        {
            await _ocorrenciaService.AddOcorrenciaAsync(ocorrenciaViewModel);
            // Retorna status 201 (Created) com a localização da nova ocorrência criada
            return CreatedAtAction(nameof(GetOcorrencia), new { id = ocorrenciaViewModel.Id }, ocorrenciaViewModel);
        }

        // Endpoint para atualizar uma ocorrência existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencia(int id, OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (id != ocorrenciaViewModel.Id)
            {
                return BadRequest(); // Retorna status 400 (Bad Request) se os IDs não coincidirem
            }

            await _ocorrenciaService.UpdateOcorrenciaAsync(ocorrenciaViewModel);
            return NoContent(); // Retorna status 204 (No Content) após a atualização bem-sucedida
        }

        // Endpoint para deletar uma ocorrência existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcorrencia(int id)
        {
            await _ocorrenciaService.DeleteOcorrenciaAsync(id);
            return NoContent(); // Retorna status 204 (No Content) após a exclusão bem-sucedida
        }
    }
}

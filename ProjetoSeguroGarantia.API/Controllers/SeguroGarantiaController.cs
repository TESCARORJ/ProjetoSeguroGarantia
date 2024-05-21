using Microsoft.AspNetCore.Mvc;
using ProjetoSeguroGarantia.Application.Commands;
using ProjetoSeguroGarantia.Application.DTOs;
using ProjetoSeguroGarantia.Application.Interfaces;

namespace ProjetoSeguroGarantia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroGarantiaController:ControllerBase
    {
        //atributo
        private readonly ISeguroGarantiaApplicationService? _seguroGarantiaApplicationService;

        //construtor para injeção de dependência
        public SeguroGarantiaController(ISeguroGarantiaApplicationService? seguroGarantiaApplicationService)
        {
            _seguroGarantiaApplicationService = seguroGarantiaApplicationService;
        }

        /// <summary>
        /// Serviço para cadastro de seguroGarantias.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(SeguroGarantiaDTO), 201)]
        public async Task<IActionResult> Post(SeguroGarantiaCreateCommand command)
        {
            var dto = await _seguroGarantiaApplicationService.Create(command);
            return StatusCode(201, dto);
        }

        /// <summary>
        /// Serviço para atualiação de seguroGarantias.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(SeguroGarantiaDTO), 200)]
        public async Task<IActionResult> Put(SeguroGarantiaUpdateCommand command)
        {
            var dto = await _seguroGarantiaApplicationService.Update(command);
            return StatusCode(200, dto);
        }

        /// <summary>
        /// Serviço para exclusão / inativação de seguroGarantias.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SeguroGarantiaDTO), 200)]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var command = new SeguroGarantiaDeleteCommand { Guid = guid };
            var dto = await _seguroGarantiaApplicationService.Delete(command);

            return StatusCode(200, dto);
        }

        /// <summary>
        /// Serviço para consulta de seguroGarantias.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<SeguroGarantiaDTO>), 200)]
        public IActionResult GetAll()
        {
            var dtos = _seguroGarantiaApplicationService.GetAll();
            return StatusCode(200, dtos);
        }

        /// <summary>
        /// Serviço para consulta de seguroGarantia por id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SeguroGarantiaDTO), 200)]
        public IActionResult GetById(Guid id)
        {
            var dto = _seguroGarantiaApplicationService.GetById(id);
            return StatusCode(200, dto);
        }
    }
}

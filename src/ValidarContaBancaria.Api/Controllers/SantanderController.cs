using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SantanderController : ControllerBase
    {
        private readonly ISantanderService _santanderService;

        public SantanderController(ISantanderService santanderService)
        {
            _santanderService = santanderService;
        }

        [HttpPost]
        [Route("ValidarDVContaCorrente")]
        [ProducesResponseType(typeof(RespostaDto<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroDto), StatusCodes.Status400BadRequest)]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_santanderService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto());
            }
        }
    }
}

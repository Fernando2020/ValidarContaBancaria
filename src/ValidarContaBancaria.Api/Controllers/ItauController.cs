using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItauController : ControllerBase
    {
        private readonly IItauService _itauService;

        public ItauController(IItauService itauService)
        {
            _itauService = itauService;
        }

        [HttpPost]
        [Route("ValidarDVContaCorrente")]
        [ProducesResponseType(typeof(RespostaDto<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroDto), StatusCodes.Status400BadRequest)]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_itauService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto());
            }
        }
    }
}

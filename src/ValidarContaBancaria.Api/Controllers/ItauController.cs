using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_itauService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto(true, "Ops, números inválidos."));
            }
        }
    }
}

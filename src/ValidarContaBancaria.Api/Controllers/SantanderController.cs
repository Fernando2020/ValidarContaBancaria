using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_santanderService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto(true, "Ops, números inválidos."));
            }
        }
    }
}

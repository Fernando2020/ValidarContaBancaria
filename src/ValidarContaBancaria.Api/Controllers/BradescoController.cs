using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BradescoController : ControllerBase
    {
        private readonly IBradescoService _bradescoService;

        public BradescoController(IBradescoService bradescoService)
        {
            _bradescoService = bradescoService;
        }

        [HttpPost]
        [Route("ValidarDVContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_bradescoService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto(true, "Ops, números inválidos."));
            }
        }
    }
}

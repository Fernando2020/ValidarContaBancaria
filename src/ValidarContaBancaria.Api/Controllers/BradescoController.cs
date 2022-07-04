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
        [Route("Agencia")]
        public IActionResult ValidarAgencia(ValidarAgenciaDto dto)
        {
            return Ok(_bradescoService.ValidarAgencia(dto));
        }

        [HttpPost]
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            return Ok(_bradescoService.ValidarContaCorrente(dto));
        }
    }
}

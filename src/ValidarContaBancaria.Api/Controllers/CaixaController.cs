using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaService _caixaService;

        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }

        [HttpPost]
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            return Ok(_caixaService.ValidarContaCorrente(dto));
        }
    }
}

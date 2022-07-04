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
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            return Ok(_santanderService.ValidarContaCorrente(dto));
        }
    }
}

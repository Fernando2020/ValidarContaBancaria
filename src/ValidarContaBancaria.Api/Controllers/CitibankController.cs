using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitibankController : ControllerBase
    {
        private readonly ICitibankService _citibankService;

        public CitibankController(ICitibankService citibankService)
        {
            _citibankService = citibankService;
        }

        [HttpPost]
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            return Ok(_citibankService.ValidarContaCorrente(dto));
        }
    }
}

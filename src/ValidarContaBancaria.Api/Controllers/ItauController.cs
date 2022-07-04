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
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            return Ok(_itauService.ValidarContaCorrente(dto));
        }
    }
}

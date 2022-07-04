using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoDoBrasilController : ControllerBase
    {
        private readonly IBancoDoBrasilService _bancoDoBrasilService;

        public BancoDoBrasilController(IBancoDoBrasilService bancoDoBrasilService)
        {
            _bancoDoBrasilService = bancoDoBrasilService;
        }

        [HttpPost]
        [Route("Agencia")]
        public IActionResult ValidarAgencia(ValidarAgenciaDto dto)
        {
            return Ok(_bancoDoBrasilService.ValidarAgencia(dto));
        }

        [HttpPost]
        [Route("ContaCorrente")]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            return Ok(_bancoDoBrasilService.ValidarContaCorrente(dto));
        }
    }
}

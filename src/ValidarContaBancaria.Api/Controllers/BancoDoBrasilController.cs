using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BancoDoBrasilController : ControllerBase
    {
        private readonly IBancoDoBrasilService _bancoDoBrasilService;

        public BancoDoBrasilController(IBancoDoBrasilService bancoDoBrasilService)
        {
            _bancoDoBrasilService = bancoDoBrasilService;
        }

        [HttpPost]
        [Route("ValidarDVContaCorrente")]
        [ProducesResponseType(typeof(RespostaDto<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroDto), StatusCodes.Status400BadRequest)]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_bancoDoBrasilService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto());
            }
        }
    }
}

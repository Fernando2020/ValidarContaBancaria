using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitibankController : ControllerBase
    {
        private readonly ICitibankService _citibankService;

        public CitibankController(ICitibankService citibankService)
        {
            _citibankService = citibankService;
        }

        [HttpPost]
        [Route("ValidarDVContaCorrente")]
        [ProducesResponseType(typeof(RespostaDto<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroDto), StatusCodes.Status400BadRequest)]
        public IActionResult ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            try
            {
                return Ok(new RespostaDto<bool>(_citibankService.ValidarContaCorrente(dto)));
            }
            catch
            {
                return BadRequest(new ErroDto());
            }
        }
    }
}

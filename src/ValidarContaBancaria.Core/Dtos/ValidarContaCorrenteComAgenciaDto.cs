using System.ComponentModel.DataAnnotations;

namespace ValidarContaBancaria.Core.Dtos
{
    public class ValidarContaCorrenteComAgenciaDto
    {
        [Required]
        public string Agencia { get; set; }

        [Required]
        public string ContaCorrente { get; set; }
    }
}

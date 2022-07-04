using System.ComponentModel.DataAnnotations;

namespace ValidarContaBancaria.Core.Dtos
{
    public class ValidarContaCorrenteDto
    {
        [Required]
        public string ContaCorrente { get; set; }
    }
}

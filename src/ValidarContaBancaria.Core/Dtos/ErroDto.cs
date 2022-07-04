namespace ValidarContaBancaria.Core.Dtos
{
    public class ErroDto
    {
        public ErroDto()
        {
            TemErro = true;
            ErroMessage = "Ops, números inválidos.";
        }

        public ErroDto(string erroMessage)
        {
            TemErro = true;
            ErroMessage = erroMessage;
        }

        public bool TemErro { get; set; }
        public string ErroMessage { get; set; }
    }
}

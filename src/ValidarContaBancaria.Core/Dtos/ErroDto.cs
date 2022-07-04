namespace ValidarContaBancaria.Core.Dtos
{
    public class ErroDto
    {
        public ErroDto(bool temErro, string erroMessage)
        {
            TemErro = temErro;
            ErroMessage = erroMessage;
        }

        public bool TemErro { get; set; }
        public string ErroMessage { get; set; }
    }
}

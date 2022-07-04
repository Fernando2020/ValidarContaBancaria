using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface IItauService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto);
    }
}

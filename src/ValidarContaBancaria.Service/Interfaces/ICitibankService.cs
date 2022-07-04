using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface ICitibankService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto);
    }
}

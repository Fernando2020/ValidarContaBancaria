using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface ISantanderService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto);
    }
}

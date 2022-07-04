using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface ICaixaService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto);
    }
}

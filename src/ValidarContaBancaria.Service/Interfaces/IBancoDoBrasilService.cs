using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface IBancoDoBrasilService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteDto dto);
    }
}

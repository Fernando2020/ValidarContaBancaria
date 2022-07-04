using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface IBradescoService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteDto dto);
    }
}

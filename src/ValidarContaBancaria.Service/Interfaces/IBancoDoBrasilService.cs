﻿using ValidarContaBancaria.Core.Dtos;

namespace ValidarContaBancaria.Service.Interfaces
{
    public interface IBancoDoBrasilService
    {
        public bool ValidarAgencia(ValidarAgenciaDto dto);
        public bool ValidarContaCorrente(ValidarContaCorrenteDto dto);
    }
}

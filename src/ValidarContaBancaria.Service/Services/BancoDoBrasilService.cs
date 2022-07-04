using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class BancoDoBrasilService : IBancoDoBrasilService
    {
        public bool ValidarAgencia(ValidarAgenciaDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 5, 4, 3, 2 };
            var dv = dto.Agencia.Last().ToString();
            var agencia = dto.Agencia.Replace("-", string.Empty);
            agencia = agencia.Substring(0, agencia.Length - 1).PadLeft(4, '0');

            for (int i = 0; i < pesos.Count; i++)
            {
                var valor = pesos[i] * Convert.ToInt32(agencia[i].ToString());
                produtos.Add(valor);
            }

            var soma = produtos.Sum();
            var modulo = soma % 11;

            var resto = modulo;

            if (resto == 10) return dv == "X";
            if (resto == 11) return dv == "0";

            var resultado = 11 - resto;

            return dv == resultado.ToString();
        }

        public bool ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2 };
            var dv = dto.ContaCorrente.Last().ToString();
            var conta = dto.ContaCorrente.Replace("-", string.Empty);
            conta = conta.Substring(0, conta.Length - 1).PadLeft(8, '0');

            for (int i = 0; i < pesos.Count; i++)
            {
                var valor = pesos[i] * Convert.ToInt32(conta[i].ToString());
                produtos.Add(valor);
            }

            var soma = produtos.Sum();
            var modulo = soma % 11;

            var resto = modulo;

            var resultado = 11 - resto;

            if (resultado == 10) return dv == "X";
            if (resultado == 11) return dv == "0";

            return dv == resultado.ToString();
        }
    }
}

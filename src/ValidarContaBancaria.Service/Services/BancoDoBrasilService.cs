using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Core.Utils;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class BancoDoBrasilService : IBancoDoBrasilService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2 };
            var conta = StringFunctions.RemoverCaracteresEspeciaisAgenciaOuConta(dto.ContaCorrente);
            var dv = conta.Last().ToString();
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

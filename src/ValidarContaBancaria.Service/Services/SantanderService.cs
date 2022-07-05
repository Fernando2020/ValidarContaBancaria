using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Core.Utils;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class SantanderService : ISantanderService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 9, 7, 3, 1, 0, 0, 9, 7, 1, 3, 1, 9, 7, 3 };
            var agencia = dto.Agencia.PadLeft(4, '0');
            var dv = dto.ContaCorrente.Last().ToString();
            var conta = StringFunctions.RemoverCaracteresEspeciaisAgenciaOuConta(dto.ContaCorrente);
            conta = conta.Substring(0, conta.Length - 1).PadLeft(8, '0');

            conta = agencia + "00" + conta;

            for (int i = 0; i < pesos.Count; i++)
            {
                var valor = (pesos[i] * Convert.ToInt32(conta[i].ToString())).ToString();
                produtos.Add(Convert.ToInt32(valor.Last().ToString()));
            }

            var soma = produtos.Sum().ToString();
            var unidadeTotal = Convert.ToInt32(soma.Last().ToString());

            if (unidadeTotal == 0) return dv == "0";

            var resultado = 10 - unidadeTotal;

            return dv == resultado.ToString();
        }
    }
}

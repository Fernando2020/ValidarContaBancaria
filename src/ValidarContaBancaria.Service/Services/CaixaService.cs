using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class CaixaService : ICaixaService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var agencia = dto.Agencia.PadLeft(4, '0');
            var dv = dto.ContaCorrente.Last().ToString();
            var conta = dto.ContaCorrente.Replace("-", string.Empty);
            conta = conta.Substring(0, conta.Length - 1).PadLeft(11, '0');

            conta = agencia + conta;

            for (int i = 0; i < pesos.Count; i++)
            {
                var valor = pesos[i] * Convert.ToInt32(conta[i].ToString());
                produtos.Add(valor);
            }

            var soma = produtos.Sum();
            var produtoSoma = soma * 10;

            var divisao = produtoSoma / 11;
            var produtoDivisao = divisao * 11;

            var resto = produtoDivisao - produtoSoma;
            resto = resto < 0 ? (resto * -1) : resto;

            if (resto == 10) return dv == "0";

            var resultado = resto;

            return dv == resultado.ToString();
        }
    }
}

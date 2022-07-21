using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Core.Utils;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class CaixaService : ICaixaService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var agencia = StringFunctions.RemoverCaracteresEspeciaisAgenciaOuConta(dto.Agencia);
            agencia = agencia.PadLeft(4, '0');
            var contaCorrente = StringFunctions.RemoverCaracteresEspeciaisAgenciaOuConta(dto.ContaCorrente);
            var dv = contaCorrente.Last().ToString();
            contaCorrente = contaCorrente.Substring(0, contaCorrente.Length - 1);
            var operacao = contaCorrente.Substring(0, 3);
            var conta = contaCorrente.Substring(3, contaCorrente.Length - 3).PadLeft(8, '0');

            conta = agencia + operacao + conta;

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

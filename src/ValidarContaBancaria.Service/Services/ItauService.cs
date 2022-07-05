using System;
using System.Collections.Generic;
using System.Linq;
using ValidarContaBancaria.Core.Dtos;
using ValidarContaBancaria.Core.Utils;
using ValidarContaBancaria.Service.Interfaces;

namespace ValidarContaBancaria.Service.Services
{
    public class ItauService : IItauService
    {
        public bool ValidarContaCorrente(ValidarContaCorrenteComAgenciaDto dto)
        {
            var produtos = new List<int>();
            var pesos = new List<int> { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            var agencia = dto.Agencia.PadLeft(4, '0');
            var dv = dto.ContaCorrente.Last().ToString();
            var conta = StringFunctions.RemoverCaracteresEspeciaisAgenciaOuConta(dto.ContaCorrente);
            conta = conta.Substring(0, conta.Length - 1).PadLeft(5, '0');

            conta = agencia + conta;

            for (int i = 0; i < pesos.Count; i++)
            {
                var valor = pesos[i] * Convert.ToInt32(conta[i].ToString());
                if(valor > 9)
                {
                    var arr = valor.ToString().ToCharArray();
                    valor = Convert.ToInt32(arr[0].ToString()) + Convert.ToInt32(arr[1].ToString());
                }
                produtos.Add(Convert.ToInt32(valor));
            }

            var soma = produtos.Sum();
            var modulo = soma % 10;

            var resto = modulo;

            if (resto == 0) return dv == "0";

            var digito = 10 - resto;

            return dv == digito.ToString();
        }
    }
}

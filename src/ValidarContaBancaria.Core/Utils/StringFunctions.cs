namespace ValidarContaBancaria.Core.Utils
{
    public static class StringFunctions
    {
        public static string RemoverCaracteresEspeciaisAgenciaOuConta(string agenciaOuConta = "")
        {
            return agenciaOuConta
                .Trim()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);
        }
    }
}

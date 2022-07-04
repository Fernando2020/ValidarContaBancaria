namespace ValidarContaBancaria.Core.Dtos
{
    public class RespostaDto<T>
    {
        public RespostaDto(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}

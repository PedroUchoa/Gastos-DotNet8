namespace Gastos_DotNet8.Models
{
    public class ResponseModel<T>
    {
        public T? Data {  get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}

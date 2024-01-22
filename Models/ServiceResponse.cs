namespace WebApi.Models
{
    public class ServiceResponse<T>
    {
        public T? Datas { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Sucess { get; set; } = true;
    }
}

namespace Ronvell.Models
{
    public class Response<T>
    {
       public bool IsSuccess { get; set; } = true;
       public string Message { get; set; } = "İşlem başarılı bir şekilde gerçekleşti";
       public T Data { get; set; }
    }
}


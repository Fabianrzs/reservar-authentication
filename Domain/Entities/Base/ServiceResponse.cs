
namespace Domain.Entities.Base;

public class ServiceResponse<T>(string message, T data, bool success)
{
    public string Message { get; set; } = message;
    public T Data { get; set; } = data;
    public bool Success { get; set; } = success;
}

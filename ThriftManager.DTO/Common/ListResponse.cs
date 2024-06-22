namespace ThriftManager.DTO.Common;

public class ListResponse<T> : IServiceResponse
{
    public List<T> Items { get; set; } = new List<T>();
    public bool IsSuccessful { get; set; }
    public string? Error { get; set; }
    public string? TechMessage { get; set; }
}

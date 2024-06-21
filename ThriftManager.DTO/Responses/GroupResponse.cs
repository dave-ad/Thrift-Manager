namespace ThriftManager.DTO.Responses;

public class GroupResponse : IServiceResponse
{
    public int GroupId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

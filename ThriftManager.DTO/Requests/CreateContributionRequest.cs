namespace ThriftManager.DTO.Requests;

public class CreateContributionRequest
{
    public string Title { get; set; } = default!;
    public int GroupId { get; set; }
}

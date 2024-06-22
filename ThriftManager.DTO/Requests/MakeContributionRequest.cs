namespace ThriftManager.DTO.Requests;

public class MakeContributionRequest
{
    public long contributionId { get; set; }
    public int memberId { get; set; }
    public decimal amount { get; set; }
}

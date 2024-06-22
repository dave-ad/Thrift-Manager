namespace ThriftManager.DTO.Responses;

public class ContributionResponse : IServiceResponse
{
    public long ContributionId { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    //public int AdminId { get; set; }
    public SessionStatus Status { get; set; }

    //public int GroupId { get; set; }
    //public List<ContributionResponse> Contributions { get; set; } = new List<ContributionResponse>();
}
namespace ThriftManager.DTO.Requests;

public class JoinContributionRequest
{
    public int GroupId { get; set; }
    public int MemberId { get; set; }
    public int Slots { get; set; }
}

namespace ThriftManager.DTO.Requests;

public class AddContributingMemberRequest
{
    public long ContributionId { get; set; }
    public int MemberId { get; set; }
    public int GroupId { get; set; }
}
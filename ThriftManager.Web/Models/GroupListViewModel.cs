namespace ThriftManager.Web.Models;

public class GroupListViewModel
{
    public List<GroupResponse> Groups { get; set; } = new List<GroupResponse>();
    public JoinGroupRequest JoinGroupRequest { get; set; } = new JoinGroupRequest();
    public JoinContributionRequest JoinContributionRequest { get; set; } = new JoinContributionRequest();
}

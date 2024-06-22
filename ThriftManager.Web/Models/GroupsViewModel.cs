namespace ThriftManager.Web.Models;

public class GroupsViewModel
{
    public int Memberid { get; set; }
    public List<GroupIdResponse> Groups { get; set; }
}
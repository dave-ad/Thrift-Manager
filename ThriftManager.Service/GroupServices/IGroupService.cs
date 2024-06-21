namespace ThriftManager.Service.GroupServices;

public interface IGroupService
{
    Task<ServiceResponse<GroupIdResponse>> CreateGroup(CreateGroupRequest request);
    Task<ServiceResponse<GroupIdResponse>> JoinGroup(int memberId, int groupId);
    //Task<ServiceResponse<IEnumerable<GroupResponse>>> ViewAllGroups();
}

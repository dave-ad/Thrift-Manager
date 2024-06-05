namespace ThriftManager.Service.GroupServices;

public interface IGroupService
{
    Task<ServiceResponse<GroupIdResponse>> CreateGroup(CreateGroupRequest request);
    //Task<ServiceResponse<IEnumerable<GroupResponse>>> ViewAllGroups();
}

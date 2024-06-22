namespace ThriftManager.Service.GroupServices;

public interface IGroupService
{
    Task<ServiceResponse<GroupIdResponse>> CreateGroup(CreateGroupRequest request);
    //Task<ServiceResponse<GroupIdResponse>> JoinGroup(JoinGroupRequest request);
    //Task<IServiceResponse> GetAllGroups();
    Task<ListResponse<GroupResponse>> GetAvailableGroups();
}
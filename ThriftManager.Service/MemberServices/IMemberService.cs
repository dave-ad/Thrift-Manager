namespace ThriftManager.Service.MemberServices;

public interface IMemberService
{
    Task<ServiceResponse<MemberIdResponse>> CreateMember(CreateMemberRequest request);
}

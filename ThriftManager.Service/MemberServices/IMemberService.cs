namespace ThriftManager.Service.MemberServices;

public interface IMemberService
{
    Task<ServiceResponse<MemberIdResponse>> CreateMember(CreateMemberRequest request);
    Task<IEnumerable<Bank>> GetBanksAsync(); // Add this line
}

namespace ThriftManager.Service.ContributionServices;

public interface IContributionService
{
    //Task<ServiceResponse<List<Contribution>>> GetContributionsByGroupId(int groupId);
    Task<ServiceResponse<ContributionResponse>> CreateContribution(CreateContributionRequest request);
    //Task<ServiceResponse> AddMemberToContribution(long contributionId, int memberId);
    Task<ServiceResponse> InitWallet(InitWalletRequest request);
    Task<ServiceResponse> MakeContribution(MakeContributionRequest request);
    Task<ServiceResponse<ContributionResponse>> AddContributingMember(AddContributingMemberRequest request);
}

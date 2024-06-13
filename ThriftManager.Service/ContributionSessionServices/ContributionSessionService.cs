//using Azure.Core;
//using ThriftManager.Utils.Enums;

//namespace ThriftManager.Service.ContributionServices;

//public sealed class ContributionSessionService(IThriftAppDbContext thriftAppDbContext) : IContributionSessionService
//{
//    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

//    //public async Task<ServiceResponse> CreateContributionSession(int groupId)
//    public async Task<ServiceResponse> CreateContributionSession(CreateContributionSessionRequest request)
//    {
//        var resp = new ServiceResponse();

//        try
//        {            
//            var session = ContributionSession.Create(
//                request.Title,
//                request.GroupId,
//                request.Slots,
//                request.ContributionAmount,
//                request.Period,
//                request.Tenure
//                );

//            session.CreateWallet(
//                "title",
//                "walletNumber",
//                "accountNumber",
//                "accountName",
//                1
//                );

//            _thriftAppDbContext.ContributionSessions.Add(session);
//            await _thriftAppDbContext.SaveChangesAsync();

//            return new ServiceResponse { IsSuccessful = true };
//        }
//        catch (Exception ex)
//        {
//            resp.Error = "Error creating contribution session";
//            resp.TechMessage = ex.Message;
//            resp.IsSuccessful = false;
//        }
//        return resp;
//    }


//    public async Task<ServiceResponse> AddMemberToContributionSession(long contributionSessionId, int memberId)
//    {
//        var resp = new ServiceResponse();

//        try
//        {
//            var session = _thriftAppDbContext.ContributionSessions
//                .Include(x => x.SessionMembers)
//                .SingleOrDefault(x => x.ContributionSessionId == contributionSessionId);

//            if (session == null)
//            {
//                return new ServiceResponse { IsSuccessful = false, Error = "Contribution session not found" };
//            }

//            session.AddMember(memberId);
//            await _thriftAppDbContext.SaveChangesAsync();

//            return new ServiceResponse { IsSuccessful = true };
//        }
//        catch (Exception ex)
//        {
//            resp.Error = "Error adding member to contribution session";
//            resp.TechMessage = ex.Message;
//            resp.IsSuccessful = false;
//        }
//        return resp;
//    }

//    public async Task<ServiceResponse> MakeContribution(long contributionSessionId, int memberId, decimal amount)
//    {
//        var session = await _thriftAppDbContext.ContributionSessions.FindAsync(contributionSessionId);
//        if (session == null)
//        {
//            return new ServiceResponse { IsSuccessful = false, Error = "Contribution session no found" };
//        }

//        try
//        {
//            session.MakeContribution(memberId, amount);
//            await _thriftAppDbContext.SaveChangesAsync();

//            return new ServiceResponse { IsSuccessful = true };
//        }
//        catch (InvalidOperationException ex)
//        {
//            return new ServiceResponse { IsSuccessful = false, Error = ex.Message };
//        }
//    }
//}
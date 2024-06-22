using Azure;
using Microsoft.EntityFrameworkCore;
using ThriftManager.Domain.Entities;
using ThriftManager.Utils.Enums;

namespace ThriftManager.Service.ContributionServices;

public class ContributionService(IThriftAppDbContext thriftAppDbContext) : IContributionService
{
    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

    public async Task<ServiceResponse<ContributionResponse>> AddContributingMember(AddContributingMemberRequest request)
    {
        var resp = new ServiceResponse<ContributionResponse>();

        try
        {
            var contribution = await _thriftAppDbContext.Contributions
               .Include(c => c.ContributingMembers)
               .FirstOrDefaultAsync(c => c.ContributionId == request.ContributionId);

            if (contribution == null)
            {
                resp.Error = "Contribution not found";
                resp.IsSuccessful = false;
                return resp;
            }

            if (contribution.ContributingMembers.Count >= contribution.Timeline.Tenure)
            {
                // Create a new contribution
                var newContributionResponse = await CreateContribution(new CreateContributionRequest
                {
                    Title = "New Contribution",
                    GroupId = contribution.GroupId
                });

                if (!newContributionResponse.IsSuccessful)
                {
                    resp.Error = "Error creating a new contribution";
                    resp.IsSuccessful = false;
                    return resp;
                }

                contribution = await _thriftAppDbContext.Contributions
                    .Include(c => c.ContributingMembers)
                    .FirstOrDefaultAsync(c => c.ContributionId == newContributionResponse.Value.ContributionId);

                if (contribution == null)
                {
                    resp.Error = "New Contribution not found";
                    resp.IsSuccessful = false;
                    return resp;
                }
            }

            var contributingMember = contribution.AddContributingMember(request.MemberId);
            await _thriftAppDbContext.SaveChangesAsync();

            resp.Value = new ContributionResponse
            {
                ContributionId = contribution.ContributionId,
                Title = contribution.Title,
                Amount = contribution.Amount,
                StartDate = contribution.StartDate,
                EndDate = contribution.EndDate,
                Status = contribution.Status
            };
            resp.IsSuccessful = true;
            return resp;

        }
        catch (Exception ex)
        {
            resp.Error = "An error occurred while joining the contribution";
            resp.TechMessage = ex.GetBaseException().Message;
            resp.IsSuccessful = false;
            return resp;
        }
    }

    public async Task<ServiceResponse<ContributionResponse>> CreateContribution(CreateContributionRequest request)
    {
        var resp = new ServiceResponse<ContributionResponse>();

        try
        {
            var group = await _thriftAppDbContext.Groups.FindAsync(request.GroupId);

            if (group == null)
            {
                resp.Error = "Contribution not found";
                resp.IsSuccessful = false;
                return resp;
            }

            var contribution = Contribution.Create(request.Title, group);
            _thriftAppDbContext.Contributions.Add(contribution);
            await _thriftAppDbContext.SaveChangesAsync();


            var contributionResponse = new ContributionResponse
            {
                ContributionId = contribution.ContributionId,
                Title = contribution.Title,
                Amount = contribution.Amount,
                StartDate = contribution.StartDate,
                EndDate = contribution.EndDate,
                Status = contribution.Status
            };

            resp.Value= contributionResponse;
            resp.IsSuccessful = true;
            return resp;
        }
        catch (Exception ex)
        {
            resp.Error = "Error occurred while creating new contribution";
            resp.TechMessage = ex.GetBaseException().Message;
            resp.IsSuccessful = false;
            return resp;
        }
    }

    public async Task<ServiceResponse> InitWallet(InitWalletRequest request)
    {
        try
        {
            var contribution = await _thriftAppDbContext.Contributions.FindAsync(request.contributionId);

            if (contribution == null)
            {
                return new ServiceResponse { IsSuccessful = false, Error = "Contribution not found" };
            }

            contribution.InitWallet(request.title, request.walletNumber, request.account);

            await _thriftAppDbContext.SaveChangesAsync();

            return new ServiceResponse { IsSuccessful = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { IsSuccessful = false, Error = "An error occurred while initializing wallet" };
        }
    }

    public async Task<ServiceResponse> MakeContribution(MakeContributionRequest request)
    {
        try
        {
            var contribution = await _thriftAppDbContext.Contributions
                .Include(c => c.ContributionWallet)
                .SingleOrDefaultAsync(c => c.ContributionId == request.contributionId);

            if (contribution == null)
            {
                return new ServiceResponse { IsSuccessful = false, Error = "Contribution not found" };
            }

            contribution.MakeContribution(request.memberId, request.amount);

            await _thriftAppDbContext.SaveChangesAsync();

            return new ServiceResponse { IsSuccessful = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse { IsSuccessful = false, Error = "An error occurred while making contribution" };
        }
    }
}
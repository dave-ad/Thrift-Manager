namespace ThriftManager.Service.GroupServices;

public sealed class GroupService(IThriftAppDbContext thriftAppDbContext) : IGroupService
{
    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

    public async Task<ServiceResponse<GroupIdResponse>> CreateGroup(CreateGroupRequest request)
    {
        var resp = new ServiceResponse<GroupIdResponse>();

        var validationResponse = ValidateRequest(request);
        if (!validationResponse.IsSuccessful)
        {
            return validationResponse;
        }

        var existingGroup = _thriftAppDbContext.Groups
            .FirstOrDefault(a => a.Name == request.Name);

        if (existingGroup != null)
        {
            resp.Error = $"Duplicate Error. {request.Name} already exists.";
            resp.TechMessage = "Duplicate Error. A member with the provided details already exists.";
            resp.IsSuccessful = false;
            return resp;
        }

        var contributionTimeline = ContributionTimeline.Create(request.Slots
            , request.Period, request.Tenure, request.DueDay);

        var group = Domain.Entities.Group.Create(request.Name, request.Title, contributionTimeline, request.Amount, request.CreatedBy);

        try
        {
            var retGroup = _thriftAppDbContext.Groups.Add(group);
            await _thriftAppDbContext.SaveChangesAsync();

            if (retGroup == null || retGroup.Entity.GroupId < 1)
            {
                resp.Error = "Error occured while creating the group";
                resp.TechMessage = "Unknown Database Error";
                resp.IsSuccessful = false;
                return resp;
            }

            resp.Value = new GroupIdResponse { GroupId = retGroup.Entity.GroupId };
            resp.IsSuccessful = true;
            return resp;
        }
        catch (DbUpdateException ex)
        {
            resp.Error = "Error Occurred";
            resp.TechMessage = ex.GetBaseException().Message;
            resp.IsSuccessful = false;
            return resp;
        }
    }

    private ServiceResponse<GroupIdResponse> ValidateRequest(CreateGroupRequest request)
    {
        var resp = new ServiceResponse<GroupIdResponse>();

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            resp.Error = "Group Name is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            resp.Error = "Group Title is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.Slots <= 0)
        {
            resp.Error = "Slots must be greater than 0.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.Period <= 0)
        {
            resp.Error = "Period must be greater than 0.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.Tenure <= 0)
        {
            resp.Error = "Tenure must be greater than 0.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.DueDay <= 0 || request.DueDay > 31)
        {
            resp.Error = "Due Day must be between 1 and 31.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.Amount <= 0)
        {
            resp.Error = "Amount must be greater than 0.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.CreatedBy))
        {
            resp.Error = "CreatedBy is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        return new ServiceResponse<GroupIdResponse> { IsSuccessful = true };
    }

    public async Task<ListResponse<GroupResponse>> GetAvailableGroups()
    {
        var resp = new ListResponse<GroupResponse>();

        try
        {
            var groups = await _thriftAppDbContext.Groups
                .Include(g => g.Contributions)
                .Select(g => new GroupResponse
                {
                    GroupId = g.GroupId,
                    Name = g.Name,
                    Title = g.Title,
                    Amount = g.Amount,
                    CreatedBy = g.CreatedBy,
                    CreatedOn = g.CreatedOn,
                    UpdatedOn = g.UpdatedOn
                }).ToListAsync();

            resp.Items = groups;
            resp.IsSuccessful = true;

            if (groups == null || !groups.Any())
            {
                resp.Error = "No groups found";
                resp.TechMessage = "No groups were found in the database";
                resp.IsSuccessful = false;
                return resp;
            }
        }
        catch (Exception ex)
        {
            resp.Error = "An error occurred while retrieving the groups.";
            resp.TechMessage = ex.GetBaseException().Message;
            resp.IsSuccessful = false;
        }

        return resp;
    }

    //public async Task<ServiceResponse<GroupIdResponse>> JoinGroup(JoinGroupRequest request)
    //{
    //    var resp = new ServiceResponse<GroupIdResponse>();

    //    try
    //    {
    //        var group = await _thriftAppDbContext.Groups
    //           .Include(g => g.Contributions)
    //           .FirstOrDefaultAsync(g => g.GroupId == request.GroupId);

    //        if (group == null)
    //        {
    //            resp.Error = "Group not found";
    //            resp.IsSuccessful = false;
    //            return resp;
    //        }


    //        var currentSlotCount = group.Contributions.Count();
    //        if (currentSlotCount >= group.Timeline.Slots)
    //        {
    //            resp.Error = "No available slots in the current group.";
    //            resp.IsSuccessful = false;
    //            return resp;
    //        }

    //        var member = await _thriftAppDbContext.Members.FindAsync(request.MemberId);
    //        if (member == null)
    //        {
    //            resp.Error = "Member not found";
    //            resp.IsSuccessful = false;
    //            return resp;
    //        }

    //        var newGroupMember = GroupMember.Create(request.GroupId, request.MemberId, currentSlotCount + 1);
    //        group.Contributions.Add(newGroupMember);

    //        try
    //        {
    //            await _thriftAppDbContext.SaveChangesAsync();
    //            resp.Value = new GroupIdResponse { GroupId = group.GroupId };
    //            resp.IsSuccessful = true;
    //            return resp;
    //        }
    //        catch (Exception ex)
    //        {
    //            resp.Error = "An error occurred while joining the group";
    //            resp.TechMessage = ex.GetBaseException().Message;
    //            resp.IsSuccessful = false;
    //            return resp;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        resp.Error = "An error occurred while retrieving the group";
    //        resp.TechMessage = ex.GetBaseException().Message;
    //        resp.IsSuccessful = false;
    //        return resp;
    //    }
    //    //return resp;
    //}

}
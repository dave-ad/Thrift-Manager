namespace ThriftManager.Service.GroupServices;

public sealed class GroupService(IThriftAppDbContext thriftAppDbContext) : IGroupService
{
    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

    public async Task<ServiceResponse<GroupIdResponse>> CreateGroup(CreateGroupRequest request)
    {
        var resp = new ServiceResponse<GroupIdResponse>();

        var contributionTimeline = ContributionTimeline.Create(request.Slots
            , request.Period, request.Tenure, request.DueDay);

        var group = Group.Create(request.Name, request.Title, contributionTimeline, request.Amount, request.CreatedBy);

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

    //public async Task<ServiceResponse<IEnumerable<GroupResponse>>> ViewAllGroups()
    //{
    //    var resp = new ServiceResponse<IEnumerable<GroupResponse>>();

    //    try
    //    {
    //        var groups = await _thriftAppDbContext.Groups.ToListAsync();

    //        if (groups == null || !groups.Any())
    //        {
    //            resp.Error = "No groups found";
    //            resp.IsSuccessful = false;
    //            return resp;
    //        }

    //        var groupResponses = groups.Select(g => new GroupResponse
    //        {
    //            GroupId = g.GroupId,
    //            Name = g.Name,
    //            Title = g.Title,
    //            Amount = g.Amount,
    //            CreatedBy = g.CreatedBy,
    //            CreatedOn = g.CreatedOn,
    //            UpdatedOn = g.UpdatedOn
    //        }).ToList();

    //        resp.Value = groupResponses;
    //        resp.IsSuccessful = true;
    //        return resp;
    //    }
    //    catch (Exception ex)
    //    {
    //        resp.Error = "Error occurred";
    //        resp.TechMessage = ex.GetBaseException().Message;
    //        resp.IsSuccessful = false;
    //        return resp;
    //    }
    //}

    //public async Task<ServiceResponse<GroupIdResponse>> JoinGroup(int memberId, int groupId)
    //{
    //    var resp = new ServiceResponse<GroupIdResponse>();

    //    var group = await _thriftAppDbContext.Groups
    //        .Include(x => x.GroupMembers)
    //        .FirstOrDefaultAsync(x => x.GroupId == groupId);

    //    if (group == null)
    //    {
    //        resp.Error = "Group not found";
    //        resp.IsSuccessful = false;
    //        return resp;
    //    }

    //    if (group.GroupMembers.Count >= group.Timeline.Slots)
    //    {
    //        resp.Error = "The group is already full.";
    //        resp.IsSuccessful = false;
    //        return resp;
    //    }

    //    var member = await _thriftAppDbContext.Members.FindAsync(memberId);
    //    if (member == null)
    //    {
    //        resp.Error = "Member not found";
    //        resp.IsSuccessful = false;
    //        return resp;
    //    }


    //    try
    //    {
    //        group.AddMember(member);
    //        await _thriftAppDbContext.SaveChangesAsync();

    //        resp.Value = new GroupIdResponse { GroupId = group.GroupId };
    //        resp.IsSuccessful = true;
    //        return resp;
    //    }
    //    catch (Exception ex)
    //    {
    //        resp.Error = "An error occurred while joining the group";
    //        resp.TechMessage = ex.GetBaseException().Message;
    //        resp.IsSuccessful = false;
    //        return resp;

    //    }
    //    //return resp;
    //}

}
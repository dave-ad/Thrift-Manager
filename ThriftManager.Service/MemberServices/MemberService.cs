namespace ThriftManager.Service.MemberServices;

public sealed class MemberService(IThriftAppDbContext thriftAppDbContext) : IMemberService
{
    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

    public async Task<ServiceResponse<MemberIdResponse>> CreateMember(CreateMemberRequest request)
    {
        var resp = new ServiceResponse<MemberIdResponse>();
        //Validate the request object
        //Validate if member already exist

        var check = _thriftAppDbContext.Members.FirstOrDefault(m => m.Email.Value.Trim().ToLower() == request.Email.Trim().ToLower());
        if (check != null && check.MemberId > 0)
        {
            resp.Error = "Duplicate Error. You have already registered";
            resp.TechMessage = "Duplicate Error. You have already registered";
            resp.IsSuccessful = false;
            return resp;
        }

        var fullName = FullName.Create(request.LastName, request.FirstName, request.OtherNames);
        var email = Email.Create(request.Email);
        var mobileNo = MobileNo.Create(request.MobileNumber);
        var nin = NIN.Create(request.NIN);
        var account = BankAccount.Create(request.Account.AccountNumber,
            request.Account.AccountName, request.Account.BVN, request.Account.BankId);




        var walletNo = AutoGens.GenerateWalletNo();

        var member = Member.Create(fullName, request.Gender, request.DateOfBirth,
            email, mobileNo, nin, walletNo, account);

        try
        {
            var retMember = _thriftAppDbContext.Members.Add(member);
            await _thriftAppDbContext.SaveChangesAsync();

            if (retMember == null || retMember.Entity.MemberId < 1)
            {
                resp.Error = "Error Occurred";
                resp.TechMessage = "Unknown Database Error";
                resp.IsSuccessful = false;
                return resp;
            }

            resp.Value = new MemberIdResponse { MemberId = retMember.Entity.MemberId };
            resp.IsSuccessful = true;
            return resp;
        }
        catch (Exception ex)
        {
            resp.Error = "Error Occurred";
            resp.TechMessage = ex.GetBaseException().Message;
            resp.IsSuccessful = false;
            return resp;
        }


    }
}

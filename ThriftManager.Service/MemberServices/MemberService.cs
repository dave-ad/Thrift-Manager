namespace ThriftManager.Service.MemberServices;

public sealed class MemberService(IThriftAppDbContext thriftAppDbContext) : IMemberService
{
    private readonly IThriftAppDbContext _thriftAppDbContext = thriftAppDbContext;

    public async Task<ServiceResponse<MemberIdResponse>> CreateMember(CreateMemberRequest request)
    {
        var resp = new ServiceResponse<MemberIdResponse>();
        //Validate the request object

        var validationResponse = ValidateRequest(request);
        if (!validationResponse.IsSuccessful)
        {
            return validationResponse;
        }

        //var existingMember = _thriftAppDbContext.Members
        //    .FirstOrDefault(a => a.Email.Value.Trim().ToLower() == request.Email.Trim().ToLower() ||
        //                         a.NIN.Value == request.NIN || 
        //                         a.BankAccount.BVN == request.Account.BVN || 
        //                         a.BankAccount.AccountNo == request.Account.AccountNumber || 
        //                         a.MobileNumber.Value == request.MobileNumber);

        //if (existingMember != null)
        //{
        //    resp.Error = "Duplicate Error. A member with the provided details already exists.";
        //    resp.TechMessage = "Duplicate Error. A member with the provided details already exists.";
        //    resp.IsSuccessful = false;
        //    return resp;
        //}

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

    private ServiceResponse<MemberIdResponse> ValidateRequest(CreateMemberRequest request)
    {
        var resp = new ServiceResponse<MemberIdResponse>();

        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            resp.Error = "First Name is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            resp.Error = "Last Name is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            resp.Error = "Email is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.MobileNumber))
        {
            resp.Error = "Mobile Number is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.NIN))
        {
            resp.Error = "NIN is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (request.Account == null || string.IsNullOrWhiteSpace(request.Account.AccountNumber))
        {
            resp.Error = "Account Number is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        if (string.IsNullOrWhiteSpace(request.Account.BVN))
        {
            resp.Error = "BVN is required.";
            resp.IsSuccessful = false;
            return resp;
        }

        return new ServiceResponse<MemberIdResponse> { IsSuccessful = true };
    }
}
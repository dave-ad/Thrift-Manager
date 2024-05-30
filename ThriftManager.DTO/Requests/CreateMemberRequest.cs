namespace ThriftManager.DTO.Requests;

public class CreateMemberRequest
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string OtherNames { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string NIN { get; set; } = string.Empty;
    public MemberBankAccount Account { get; set; } = default!;
}

public class MemberBankAccount
{
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public int BankId { get; set; }
    public string BVN { get; set; }
}
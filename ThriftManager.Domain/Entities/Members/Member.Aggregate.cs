namespace ThriftManager.Domain.Entities;

public partial class Member : IAggregateRoot
{
    private Member() { }
    //private Member(FullName name, Gender gender, DateOnly dateOfBirth, Email email, MobileNo mobileNumber,
    //    NIN nIN, string walletNumber, BankAccount account, BankAccount bankAccount)
    private Member(FullName name, Gender gender, DateOnly dateOfBirth, Email email, MobileNo mobileNumber, NIN nin, MemberStatus status, BankAccount bankAccount, MemberWallet memberWallet)
    {
        Name = name;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = email;
        MobileNumber = mobileNumber;
        NIN = nin;
        Status = status;
        BankAccount = bankAccount;
        MemberWallet = memberWallet;
    }

    public static Member Create(FullName name, Gender gender, DateOnly dateOfBirth, Email email, MobileNo mobileNumber, NIN nin, BankAccount bankAccount)
    {
        var member = new Member(name, gender, dateOfBirth, email, mobileNumber, nin, MemberStatus.Active, bankAccount, null);
        var memberWallet = new MemberWallet(member.MemberId, AutoGens.GenerateWalletNo(), bankAccount);
        member.MemberWallet = memberWallet;
        return member;
    }

    public void Update(FullName name, MobileNo mobileNumber, Gender gender)
    {
        Name = name;
        Gender = gender;
        MobileNumber = mobileNumber; ;
    }

    public void CreditWallet(decimal amount)
    {
        MemberWallet.Credit(amount);
    }

    public void DebitWallet(decimal amount)
    {
        MemberWallet.Debit(amount);
    }

}

using ThriftManager.Domain.ValueObjects;

namespace ThriftManager.Domain.Entities;

public partial class Member : IAggregateRoot
{
    private Member() { }

    private Member(FullName name, Gender gender, DateOnly dateOfBirth, Email email, MobileNo mobileNumber,
        NIN nIN, string walletNumber, BankAccount account)
    {
        Name = name;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = email;
        MobileNumber = mobileNumber;
        NIN = nIN;
        Status = MemberStatus.Registered;

        MemberWallet = new MemberWallet(MemberId, walletNumber, account);
        //MemberAddress = memberAddress;
    }

    public static Member Create(FullName name, Gender gender, DateOnly dateOfBirth, Email email, MobileNo mobileNumber,
        NIN nIN, string walletNumber, BankAccount account)
    {
        return new Member(name, gender, dateOfBirth, email, mobileNumber, nIN, walletNumber, account);
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

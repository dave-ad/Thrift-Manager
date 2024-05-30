using ThriftManager.Domain.ValueObjects;

namespace ThriftManager.Domain.Entities;

public partial class Member : IAggregateRoot
{
    private Member() { }

    private Member(string lastName, string firstName, string otherNames,
        Gender gender, DateOnly dateOfBirth, string email,
        string mobileNumber, string nIN, string walletNumber, string accountNumber,
        string accountName, string bvn, int bankId)
    {
        Name = FullName.Create(lastName, firstName, otherNames);
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = Email.Create(email);
        MobileNumber = MobileNo.Create(mobileNumber);
        NIN = NIN.Create(nIN);
        Status = MemberStatus.Registered;

        MemberWallet = new MemberWallet(MemberId, accountNumber,
            walletNumber, accountName, bankId, bvn);

        //MemberAddress = memberAddress;
    }

    public static Member Create(string lastName, string firstName,
        string otherNames, Gender gender, DateOnly dateOfBirth, string email,
        string mobileNumber, string nIN, string walletNumber, string accountNumber,
        string accountName, string bvn, int bankId)
    {
        return new Member(lastName, firstName, otherNames, gender,
            dateOfBirth, email, mobileNumber, nIN, walletNumber,
            accountNumber, accountName, bvn, bankId);
    }

    public void Update(string lastName, string firstName, string otherNames, string mobileNumber, Gender gender)
    {
        Name = FullName.Create(lastName, firstName, otherNames);
        Gender = gender;
        MobileNumber = MobileNo.Create(mobileNumber); ;
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

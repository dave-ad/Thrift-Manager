namespace ThriftManager.Domain.Entities;

public partial class Contribution : IAggregateRoot
{
    internal Contribution() { }
    internal Contribution(string title, Group group)
    {
        var dateNow = DateTime.UtcNow;
        var dateNext = DateTime.UtcNow.AddYears(1);

        Title = title;
        GroupId = group.GroupId;
        Amount = group.Amount;
        Timeline = group.Timeline;
        StartDate = new DateOnly(dateNow.Year, dateNow.Month, dateNow.Day);
        EndDate = new DateOnly(dateNext.Year, dateNext.Month, dateNext.Day);
        AdminId = 0;
        Status = SessionStatus.Registered;
        ContributionWallet = new ContributionWallet();
    }

    public static Contribution Create(string title, Group group)
    {
        return new Contribution(title, group);
    }

    public void InitWallet(string title, string walletNumber, BankAccount account)
    {
        if (ContributionWallet.ContributionWalletId > 1)
            throw new InvalidOperationException("Contribution wallet already initialized");

        ContributionWallet =
               new ContributionWallet(ContributionId, GroupId, title, walletNumber, account, 0);

    }

    public ContributingMember AddContributingMember(int memberId)
    {
        if (_contributingMembers.Count >= Timeline.Tenure)
            throw new InvalidOperationException("Contribution slots already filled up");

        var contMember = new ContributingMember(ContributionId, memberId, 0);
        _contributingMembers.Add(contMember);

        return contMember;
    }

    //Suspend Member
    //Swap Member

    public void MakeContribution(int memberId, decimal amount)
    {
        var thisMember =
            _contributingMembers.SingleOrDefault(m => m.MemberId == memberId, new ContributingMember());

        if (thisMember.MemberId < 1)
            throw new InvalidOperationException("The supplied member information does not belong to this contribution session");

        if (amount != Amount)
            throw new InvalidOperationException($"{Amount} Expected! Amount supplied is {amount}");

        ContributionWallet.Credit(memberId, amount);
    }

    //Payout
}

namespace ThriftManager.Domain.Entities;

public partial class ContributionSession : IAggregateRoot
{
    internal ContributionSession() { }
    internal ContributionSession(string title, int groupId, int slots, decimal contributionAmount,
        Period period, int tenure)
    {
        Title = title;
        GroupId = groupId;
        Slots = slots;
        ContributionAmount = contributionAmount;
        Period = period;
        Tenure = tenure;
        DueDay = 5;
        StartDate = DateTime.UtcNow;
        EndDate = DateTime.UtcNow.AddYears(1);
        AdminId = 0;
        Status = SessionStatus.Registered;
    }

    public static ContributionSession Create(string title, int groupId, int slots, decimal contributionAmount,
        Period period, int tenure)
    {
        return new ContributionSession(title, groupId, slots, contributionAmount,
            period, tenure);
    }

    public void CreateWallet(string title, string walletNumber, string accountNumber,
        string accountName, int bankId)
    {
        if (SessionWallet != null && SessionWallet.SessionWalletId < 1)
        {
            SessionWallet = new SessionWallet(ContributionSessionId, GroupId, title,
                       walletNumber, accountNumber, accountName, bankId, 0);
        }
    }

    public void AddMember(int memberId)
    {
        if (_sessionMembers.Count >= Tenure)
            throw new InvalidOperationException("Contribution slots already filled up");

        _sessionMembers.Add(new SessionMember(ContributionSessionId, memberId, 0));

    }

    //Suspend Member
    //Swap Member

    public void MakeContribution(int memberId, decimal amount)
    {
        var thisMember =
            _sessionMembers.SingleOrDefault(m => m.MemberId == memberId, new SessionMember());

        if (thisMember.MemberId < 1)
            throw new InvalidOperationException("This member does not belong to the contribution session");

        if (amount != ContributionAmount)
            throw new InvalidOperationException($"{ContributionAmount} Expected! Amount supplied is {amount}");

        SessionWallet.Credit(memberId, amount);
    }

    //Payout
}

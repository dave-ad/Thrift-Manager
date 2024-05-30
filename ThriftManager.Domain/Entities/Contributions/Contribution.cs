

namespace ThriftManager.Domain.Entities;

public partial class Contribution
{
    public long ContributionId { get; private set; }
    public string Title { get; private set; } = default!;
    public int GroupId { get; private set; }
    public int ContributionWalletId { get; private set; }
    public ContributionTimeline Timeline { get; private set; } = ContributionTimeline.Default();
    public decimal Amount { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public int AdminId { get; private set; }
    public SessionStatus Status { get; private set; }

    public Group Group { get; private set; } = default!;
    public ContributionWallet ContributionWallet { get; private set; } = default!;
    public IReadOnlyCollection<ContributingMember> ContributingMembers => _contributingMembers;



    private readonly HashSet<ContributingMember> _contributingMembers = new HashSet<ContributingMember>();

}


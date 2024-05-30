namespace ThriftManager.Domain.Entities;

public class ContributingMember
{
    public long ContributingMemberId { get; private set; }
    public long ContributionId { get; private set; }
    public int MemberId { get; private set; }
    public int SlotPosition { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public virtual Contribution Contribution { get; private set; } = default!;
    internal ContributingMember() { }
    internal ContributingMember(long contributionId, int memberId, int slotPosition)
    {
        ContributingMemberId = contributionId;
        MemberId = memberId;
        SlotPosition = slotPosition;
        CreatedOn = DateTime.UtcNow;
    }
}

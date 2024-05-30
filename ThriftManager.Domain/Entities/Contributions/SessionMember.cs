namespace ThriftManager.Domain.Entities;

public class SessionMember
{
    public int SessionMemberId { get; private set; }
    public long ContributionSessionId { get; private set; }
    public int MemberId { get; private set; }
    public int SlotPosition { get; private set; }
    public DateTime CreatedOn { get; private set; }
    internal SessionMember() { }
    internal SessionMember(long contributionSessionId, int memberId, int slotPosition)
    {
        ContributionSessionId = contributionSessionId;
        MemberId = memberId;
        SlotPosition = slotPosition;
        CreatedOn = DateTime.UtcNow;
    }
}

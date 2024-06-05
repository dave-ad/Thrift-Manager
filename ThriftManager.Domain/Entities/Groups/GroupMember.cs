namespace ThriftManager.Domain.Entities;

public class GroupMember
{
    public int GroupMemberId { get; private set; }
    public int GroupId { get; private set; }
    public Group Group { get; private set; } = default!;
    public int MemberId { get; private set; }
    public Member Member { get; private set; } = default!;
    public int SlotNumber { get; set; }
    public DateTime JoinedOn { get; private set; }

    private GroupMember() { }

    private GroupMember(int groupId, int memberId, int slotNumber)
    {
        GroupId = groupId;
        MemberId = memberId;
        SlotNumber = slotNumber;
        JoinedOn = DateTime.UtcNow;
    }

    public static GroupMember Create(int groupId, int memberId, int slotNumber)
    {
        return new GroupMember(groupId, memberId, slotNumber);
    }
}

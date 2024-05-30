using ThriftManager.Domain.ValueObjects;

namespace ThriftManager.Domain.Entities;

public partial class Member : Entity
{
    public int MemberId { get; private set; }
    public FullName Name { get; private set; } = FullName.Default();
    public Gender Gender { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Email Email { get; private set; } = Email.Default();
    public MobileNo MobileNumber { get; private set; } = MobileNo.Default();
    public NIN NIN { get; private set; } = NIN.Default();
    public MemberStatus Status { get; private set; }

    public virtual MemberWallet MemberWallet { get; private set; } = default!;
    //public virtual MemberAddress MemberAddress { get; private set; } = default!;
}

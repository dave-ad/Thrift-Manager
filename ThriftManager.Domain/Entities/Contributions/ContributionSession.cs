namespace ThriftManager.Domain.Entities;

public partial class ContributionSession
{
    public long ContributionSessionId { get; private set; }
    public string Title { get; private set; } = default!;
    public int GroupId { get; private set; }
    public int Slots { get; private set; }
    public decimal ContributionAmount { get; private set; }
    public Period Period { get; private set; }
    public int Tenure { get; private set; }
    public int DueDay { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int AdminId { get; private set; }
    public SessionStatus Status { get; private set; }
    public SessionWallet SessionWallet { get; private set; } = new SessionWallet();

    public IReadOnlyCollection<SessionMember> SessionMembers => _sessionMembers;

    private readonly HashSet<SessionMember> _sessionMembers = new HashSet<SessionMember>();

}


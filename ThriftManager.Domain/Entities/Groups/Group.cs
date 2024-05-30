namespace ThriftManager.Domain.Entities;

public class Group
{
    public int GroupId { get; private set; }
    public string Name { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public Period Period { get; private set; }
    public decimal ContributionAmount { get; private set; }
    public int Slots { get; private set; }
    public int Tenure { get; private set; }
    public ItemStatus Status { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }

    public ICollection<ContributionSession> ContributionSessions { get; private set; }

    private Group() { }
    private Group(string name, string title, Period period, decimal contributionAmount, int slots, int tenure)
    {
        Name = name;
        Title = title;
        Period = period;
        ContributionAmount = contributionAmount;
        Slots = slots;
        Tenure = tenure;
        Status = ItemStatus.Active;
        CreatedBy = 1;
        CreatedOn = DateTime.UtcNow;
        ContributionSessions = new List<ContributionSession>();
    }

    public static Group Create(string name, string title, Period period, decimal contributionAmount, int slots, int tenure)
    {
        return new Group(name, title, period, contributionAmount, slots, tenure);
    }
}

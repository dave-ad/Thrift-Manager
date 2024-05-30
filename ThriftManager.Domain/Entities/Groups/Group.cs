namespace ThriftManager.Domain.Entities;

public class Group
{
    public int GroupId { get; private set; }
    public string Name { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public decimal Amount { get; private set; }
    public ContributionTimeline Timeline { get; private set; } = ContributionTimeline.Default();
    public ItemStatus Status { get; private set; }
    public int CreatedBy { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }

    public HashSet<Contribution> Contributions { get; private set; } = new HashSet<Contribution>();

    private Group() { }
    private Group(string name, string title, ContributionTimeline timeline, decimal amount)
    {
        Name = name;
        Title = title;
        Timeline = timeline;
        Amount = amount;
        Status = ItemStatus.Active;
        CreatedBy = 1;
        CreatedOn = DateTime.UtcNow;
    }

    public static Group Create(string name, string title, ContributionTimeline timeline, decimal amount)
    {
        return new Group(name, title, timeline, amount);
    }
}

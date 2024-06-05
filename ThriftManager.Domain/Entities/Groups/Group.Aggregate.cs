namespace ThriftManager.Domain.Entities;

public partial class Group : IAggregateRoot
{
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

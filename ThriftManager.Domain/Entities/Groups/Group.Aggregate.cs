namespace ThriftManager.Domain.Entities;

public partial class Group : IAggregateRoot
{
    private Group() { }
    private Group(string name, string title, ContributionTimeline timeline, decimal amount, string createdBy)
    {
        Name = name;
        Title = title;
        Timeline = timeline;
        Amount = amount;
        Status = ItemStatus.Active;
        CreatedBy = createdBy;
        CreatedOn = DateTime.UtcNow;
    }

    public static Group Create(string name, string title, ContributionTimeline timeline, decimal amount, string createdBy)
    {
        return new Group(name, title, timeline, amount, createdBy);
    }
}

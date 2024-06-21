namespace ThriftManager.Domain.Entities;

public partial class Group : Entity
{
    public int GroupId { get; private set; }
    public string Name { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public decimal Amount { get; private set; }
    public ContributionTimeline Timeline { get; private set; } = ContributionTimeline.Default();
    public ItemStatus Status { get; private set; }
    public string CreatedBy { get; private set; } = default!;
    public DateTime CreatedOn { get; private set; }
    public DateTime? UpdatedOn { get; private set; }

    public HashSet<Contribution> Contributions { get; private set; } = new HashSet<Contribution>();
}
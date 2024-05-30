namespace ThriftManager.Domain.Entities;

public class LocalGovtArea
{
    public int LocalGovtAreaId { get; private set; }
    public int StateId { get; private set; }
    public string Name { get; private set; } = default!;

    public virtual State State { get; private set; } = default!;
}

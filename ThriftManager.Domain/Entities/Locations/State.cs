namespace ThriftManager.Domain.Entities;

public class State
{
    public int StateId { get; private set; }
    public int CountryId { get; private set; }
    public string Name { get; private set; } = default!;

    public virtual Country Country { get; private set; } = default!;

    private HashSet<LocalGovtArea> _localGovtAreas = new HashSet<LocalGovtArea>();

}

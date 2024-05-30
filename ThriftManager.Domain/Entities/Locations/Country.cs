namespace ThriftManager.Domain.Entities;

public class Country
{
    public int CountryId { get; private set; }
    public string Name { get; private set; } = default!;

    private HashSet<State> _states = new HashSet<State>();
}

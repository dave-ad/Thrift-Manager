namespace ThriftManager.Domain.ValueObjects;

public record NIN
{
    public string Value { get; }
    public int Hash { get; }

    public NIN()
    {
        Value = "";
        Hash = 0;
    }
    public NIN(string value)
    {
        Value = value;
        Hash = value.Trim().GetHashCode();
    }
    public static NIN Default() => new();
    public static NIN Create(string value) => new NIN(value);
}

namespace ThriftManager.Domain.Entities;

public class MemberAddress
{
    public int MemberAddressId { get; private set; }
    public int MemberId { get; private set; }
    public string StreetNumber { get; private set; } = default!;
    public string StreetName { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public int CountryId { get; private set; }
    public int StateId { get; private set; }
    public int LocalGovtAreaId { get; private set; }

    public virtual Member Member { get; private set; }
    public virtual LocalGovtArea LocalGovtArea { get; private set; }

}

namespace ThriftManager.DTO.Requests;

public class CreateGroupRequest
{
    public string Name { get; set; } = default!;
    public string Title { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public int Slots { get; set; } = default!;
    public Period Period { get; set; } = default!;
    public int Tenure { get; set; } = default!;
    public int DueDay { get; set; } = default!;
    public string CreatedBy { get; set; }
}
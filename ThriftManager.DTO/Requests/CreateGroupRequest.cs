namespace ThriftManager.DTO.Requests;

/*
  public int GroupId { get; private set; }
   
    
    
    public ContributionTimeline Timeline { get; private set; } = ContributionTimeline.Default();
 */
public class CreateGroupRequest
{
    public string Name { get; set; } = default!;
    public string Title { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public int Slots { get; set; } = default!;
    public Period Period { get; set; } = default!;
    public int Tenure { get; set; } = default!;
    public int DueDay { get; set; } = default!;
}

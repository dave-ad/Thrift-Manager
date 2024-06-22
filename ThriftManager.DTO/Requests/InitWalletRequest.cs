namespace ThriftManager.DTO.Requests;

public class InitWalletRequest
{
    public int contributionId { get; set; }
    public string title { get; set; }
    public string walletNumber { get; set; }
    public BankAccount account { get; set; }
}

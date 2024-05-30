namespace ThriftManager.Domain.ValueObjects;

public record BankAccount
{
    public string AccountNo { get; }
    public string AccountName { get; }
    public string BVN { get; }
    public int BankId { get; }

    private BankAccount()
    {
        BankId = 0;
        AccountName = "";
        AccountNo = "";
        BVN = "";
    }

    private BankAccount(string accountNo, string accountName, string bvn, int bankId)
    {
        BankId = bankId;
        AccountName = accountNo;
        AccountNo = accountName;
        BVN = bvn;
    }

    public static BankAccount Default() => new();

    public static BankAccount Create(string accountNo, string accountName, string bvn, int bankId)
        => new(accountNo, accountName, bvn, bankId);
}

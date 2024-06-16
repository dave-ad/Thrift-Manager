namespace ThriftManager.Domain.ValueObjects;

public record BankAccount
{
    public string AccountNo { get; }
    public string AccountName { get; }
    public string BVN { get; }
    public string BankName { get; }

    private BankAccount()
    {
        BankName = "";
        AccountName = "";
        AccountNo = "";
        BVN = "";
    }

    private BankAccount(string accountNo, string accountName, string bvn, string bankName)
    {
        BankName = bankName;
        AccountName = accountName;
        AccountNo = accountNo;
        BVN = bvn;
    }

    public static BankAccount Default() => new();

    public static BankAccount Create(string accountNo, string accountName, string bvn, string bankName)
        => new(accountNo, accountName, bvn, bankName);
}

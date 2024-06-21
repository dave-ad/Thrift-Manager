namespace ThriftManager.Domain.ValueObjects;

public record BankAccount
{
    public string AccountNo { get; }
    public string AccountName { get; }
    public string BVN { get; }
    public string BankName { get; set; }

    private BankAccount()
    {
        AccountName = "";
        AccountNo = "";
        BVN = "";
        BankName = "";
    }

    private BankAccount(string accountNo, string accountName, string bvn, string bankName)
    {
        AccountName = accountName;
        AccountNo = accountNo;
        BVN = bvn;
        BankName = bankName;
    }

    public static BankAccount Default() => new();

    public static BankAccount Create(string accountNo, string accountName, string bvn, string bankName)
        => new(accountNo, accountName, bvn, bankName);
}

using System.ComponentModel.DataAnnotations;

namespace ThriftManager.Domain.ValueObjects;

public record BankAccount
{
    public string AccountNo { get; }
    public string AccountName { get; }
    public string BVN { get; }
    public string BankName { get; set; }
    //public Bank Bank { get; }

    private BankAccount()
    {
        AccountName = "";
        AccountNo = "";
        BVN = "";
        BankName = "";
        //Bank = null!;
    }

    //private BankAccount(string accountNo, string accountName, string bvn, Bank bank)
    private BankAccount(string accountNo, string accountName, string bvn, string bankName)
    {
        AccountName = accountName;
        AccountNo = accountNo;
        BVN = bvn;
        BankName = bankName;
    }

    public static BankAccount Default() => new();

    //public static BankAccount Create(string accountNo, string accountName, string bvn, Bank bank)
    public static BankAccount Create(string accountNo, string accountName, string bvn, string bankName)
        => new(accountNo, accountName, bvn, bankName);
}
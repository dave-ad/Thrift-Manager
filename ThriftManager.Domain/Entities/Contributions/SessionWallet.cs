namespace ThriftManager.Domain.Entities;

public class SessionWallet
{
    public long SessionWalletId { get; set; }
    public long ContributionSessionId { get; private set; }
    public int GroupId { get; private set; }
    public string Title { get; set; } = default!;
    public string WalletNumber { get; private set; } = default!;
    public string AccountNumber { get; private set; } = default!;
    public string AccountName { get; private set; } = default!;
    public int BankId { get; private set; }
    public decimal Balance { get; private set; }
    public IReadOnlyCollection<SessionWalletTransaction> WalletTransactions => _walletTransactions;

    private readonly HashSet<SessionWalletTransaction> _walletTransactions =
        new HashSet<SessionWalletTransaction>();


    internal SessionWallet() { }
    internal SessionWallet(long contributionSessionId, int groupId, string title,
        string walletNumber, string accountNumber, string accountName, int bankId,
        decimal balance)
    {
        ContributionSessionId = contributionSessionId;
        GroupId = groupId;
        Title = title;
        WalletNumber = walletNumber;
        AccountNumber = accountNumber;
        AccountName = accountName;
        BankId = bankId;
        Balance = balance;
    }

    internal void Credit(int memberId, decimal amount)
    {
        if (amount < 1)
            throw new ArgumentOutOfRangeException("Amount supplied is invalid", nameof(amount));

        _walletTransactions.Add(
            new SessionWalletTransaction(ContributionSessionId, GroupId, memberId,
            TransactionType.Credit, amount, TransStatus.Success));

        Balance += amount;
    }
}

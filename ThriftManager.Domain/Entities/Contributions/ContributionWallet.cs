namespace ThriftManager.Domain.Entities;

public class ContributionWallet
{
    public long ContributionWalletId { get; set; }
    public long ContributionId { get; private set; }
    public int GroupId { get; private set; }
    public string Title { get; set; } = default!;
    public string WalletNumber { get; private set; } = default!;
    public BankAccount Account { get; private set; } = BankAccount.Default();
    public decimal Balance { get; private set; }
    public IReadOnlyCollection<ContributionWalletTransaction> WalletTransactions => _walletTransactions;

    public virtual Contribution Contribution { get; private set; } = default!;


    private readonly HashSet<ContributionWalletTransaction> _walletTransactions =
        new HashSet<ContributionWalletTransaction>();

    internal ContributionWallet() { }
    internal ContributionWallet(long contributionId, int groupId, string title,
        string walletNumber, BankAccount account,
        decimal balance)
    {
        ContributionId = contributionId;
        GroupId = groupId;
        Title = title;
        WalletNumber = walletNumber;
        Account = account;
        Balance = balance;
    }

    internal void Credit(int memberId, decimal amount)
    {
        if (amount < 1)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount supplied is invalid");

        _walletTransactions.Add(
            new ContributionWalletTransaction(ContributionId, GroupId, memberId,
            TransactionType.Credit, amount, TransStatus.Success));

        Balance += amount;
    }
}

namespace ThriftManager.Domain.Entities;

public class MemberWallet
{
    public int MemberWalletId { get; private set; }
    public int MemberId { get; private set; }
    public string WalletNumber { get; private set; } = default!;
    public BankAccount Account { get; private set; } = BankAccount.Default();
    public decimal Balance { get; private set; }
    public virtual Member Member { get; private set; } = default!;
    public IReadOnlyCollection<MemberWalletTransaction> MemberWalletTransactions => _memberWalletTransactions;

    private HashSet<MemberWalletTransaction> _memberWalletTransactions = new HashSet<MemberWalletTransaction>();
    internal MemberWallet() { }
    internal MemberWallet(int memberId, string walletNumber, BankAccount account)
    {
        MemberId = memberId;
        WalletNumber = walletNumber;
        Account = account;
        Balance = 0;
        _memberWalletTransactions.Add(new
            MemberWalletTransaction(MemberWalletId, memberId, TransactionType.Init, 0, DateTime.UtcNow, TransStatus.Success
        ));
    }

    internal void Credit(decimal amount)
    {
        if (amount < 1)
            throw new ArgumentException("Minimum Deposit Amount is 1", nameof(amount));

        Balance += amount;

        _memberWalletTransactions.Add(new
            MemberWalletTransaction(MemberWalletId, MemberId, TransactionType.Credit, amount, DateTime.UtcNow, TransStatus.Success
        ));
    }

    internal void Debit(decimal amount)
    {
        if (amount > Balance)
            throw new ArgumentException("Insufficient Wallet Balance", nameof(amount));

        Balance -= amount;

        _memberWalletTransactions.Add(new
            MemberWalletTransaction(MemberWalletId, MemberId, TransactionType.Debit, -amount, DateTime.UtcNow, TransStatus.Success
        ));
    }

}

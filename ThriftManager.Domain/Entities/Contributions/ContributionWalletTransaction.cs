namespace ThriftManager.Domain.Entities;

public class ContributionWalletTransaction
{
    public long ContributionWalletTransactionId { get; set; }
    public long ContributionId { get; private set; }
    public int GroupId { get; private set; }
    public int MemberId { get; private set; }
    public long ContributionWalletId { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public decimal TransactionAmount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public TransStatus Status { get; private set; }

    public virtual ContributionWallet ContributionWallet { get; private set; } = default!;
    private ContributionWalletTransaction()
    {

    }

    internal ContributionWalletTransaction(long contributionId, int groupId, int memberId, TransactionType transactionType, decimal transactionAmount, TransStatus status)
    {
        ContributionId = contributionId;
        GroupId = groupId;
        MemberId = memberId;
        TransactionType = transactionType;
        TransactionAmount = transactionAmount;
        Status = status;
        TransactionDate = DateTime.UtcNow;
    }
}

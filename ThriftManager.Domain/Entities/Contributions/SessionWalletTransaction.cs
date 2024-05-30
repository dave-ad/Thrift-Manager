namespace ThriftManager.Domain.Entities;

public class SessionWalletTransaction
{
    public long SessionWalletTransactionId { get; set; }
    public long ContributionSessionId { get; private set; }
    public int GroupId { get; private set; }
    public int MemberId { get; private set; }
    public long SessionWalletId { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public decimal TransactionAmount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public TransStatus Status { get; private set; }

    private SessionWalletTransaction()
    {

    }

    internal SessionWalletTransaction(long contributionSessionId, int groupId, int memberId, TransactionType transactionType, decimal transactionAmount, TransStatus status)
    {
        ContributionSessionId = contributionSessionId;
        GroupId = groupId;
        MemberId = memberId;
        TransactionType = transactionType;
        TransactionAmount = transactionAmount;
        Status = status;
        TransactionDate = DateTime.UtcNow;
    }
}

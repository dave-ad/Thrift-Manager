

namespace ThriftManager.Domain.Entities;

public class MemberWalletTransaction
{
    public long MemberWalletTransactionId { get; private set; }
    public int MemberWalletId { get; private set; }
    public int MemberId { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public decimal TransactionAmount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public TransStatus Status { get; private set; }
    public virtual MemberWallet MemberWallet { get; private set; } = default!;

    internal MemberWalletTransaction(int memberWalletId, int memberId,
        TransactionType transactionType, decimal transactionAmount,
        DateTime transactionDate, TransStatus status)
    {
        MemberWalletId = memberWalletId;
        MemberId = memberId;
        TransactionType = transactionType;
        TransactionAmount = transactionAmount;
        TransactionDate = transactionDate;
        Status = status;
    }
}

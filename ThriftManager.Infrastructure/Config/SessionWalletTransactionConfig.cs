using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class SessionWalletTransactionConfig : IEntityTypeConfiguration<SessionWalletTransaction>
{
    public void Configure(EntityTypeBuilder<SessionWalletTransaction> builder)
    {
        builder.ToTable(nameof(SessionWalletTransaction));
        builder.HasKey(x => x.SessionWalletTransactionId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.SessionWalletTransactionId), "sessionwallettransaction_sessionwallettransactionid_seq", "ThriftSchema");
    }
}

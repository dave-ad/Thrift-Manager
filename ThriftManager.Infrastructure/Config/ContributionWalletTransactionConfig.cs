using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class ContributionWalletTransactionConfig : IEntityTypeConfiguration<ContributionWalletTransaction>
{
    public void Configure(EntityTypeBuilder<ContributionWalletTransaction> builder)
    {
        builder.ToTable(nameof(ContributionWalletTransaction));
        builder.HasKey(x => x.ContributionWalletTransactionId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.ContributionWalletTransactionId), "sessionwallettransaction_sessionwallettransactionid_seq", "ThriftSchema");
    }
}

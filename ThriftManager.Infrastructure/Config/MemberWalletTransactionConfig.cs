using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class MemberWalletTransactionConfig : IEntityTypeConfiguration<MemberWalletTransaction>
{
    public void Configure(EntityTypeBuilder<MemberWalletTransaction> builder)
    {
        builder.ToTable(nameof(MemberWalletTransaction));
        builder.HasKey(x => x.MemberWalletTransactionId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.MemberWalletTransactionId), "wallettransaction_wallettransactionid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

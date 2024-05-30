using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class SessionWalletConfig : IEntityTypeConfiguration<SessionWallet>
{
    public void Configure(EntityTypeBuilder<SessionWallet> builder)
    {
        builder.ToTable(nameof(SessionWallet));
        builder.HasKey(x => x.SessionWalletId);

        builder.HasMany(x => x.WalletTransactions).WithOne().HasForeignKey(x => x.SessionWalletId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.SessionWalletId), "SessionWallet_SessionWalletid_seq", "ThriftSchema");
    }
}

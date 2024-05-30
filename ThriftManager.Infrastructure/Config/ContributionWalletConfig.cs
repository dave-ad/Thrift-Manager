using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class ContributionWalletConfig : IEntityTypeConfiguration<ContributionWallet>
{
    public void Configure(EntityTypeBuilder<ContributionWallet> builder)
    {
        builder.ToTable(nameof(ContributionWallet));
        builder.HasKey(x => x.ContributionWalletId);

        builder.OwnsOne(x => x.Account, c =>
        {
            c.Property(x => x.AccountNo).HasMaxLength(10).IsRequired();
            c.Property(x => x.AccountName).HasMaxLength(80).IsRequired();
            c.Property(x => x.BVN).HasMaxLength(11);
            c.Property(x => x.BankId);
        });

        builder.HasMany(x => x.WalletTransactions).WithOne(x => x.ContributionWallet).HasForeignKey(x => x.ContributionWalletId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.ContributionWalletId), "contributionwallet_contributionwalletid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

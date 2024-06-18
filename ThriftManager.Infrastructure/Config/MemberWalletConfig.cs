using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class MemberWalletConfig : IEntityTypeConfiguration<MemberWallet>
{
    public void Configure(EntityTypeBuilder<MemberWallet> builder)
    {
        builder.ToTable(nameof(MemberWallet));
        builder.HasKey(x => x.MemberWalletId);

        builder.OwnsOne(x => x.Account, c =>
        {
            c.Property(x => x.AccountNo).HasMaxLength(10).IsRequired();
            c.Property(x => x.AccountName).HasMaxLength(80).IsRequired();
            c.Property(x => x.BVN).HasMaxLength(11);
            c.Property(x => x.BankId);
        });

        builder.HasMany(x => x.MemberWalletTransactions).WithOne(x => x.MemberWallet);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.MemberId), "memberwallet_memberwalletid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable(nameof(Member));
        builder.HasKey(x => x.MemberId);

        builder.OwnsOne(x => x.Name, c =>
        {
            c.Property(x => x.Last).HasMaxLength(50).IsRequired();
            c.Property(x => x.First).HasMaxLength(50).IsRequired();
            c.Property(x => x.Others).HasMaxLength(50);
        });

        builder.OwnsOne(x => x.Email, c =>
        {
            c.Property(x => x.Value).HasMaxLength(100).IsRequired();
            c.Property(x => x.Hash);
        });

        builder.OwnsOne(x => x.MobileNumber, c =>
        {
            c.Property(x => x.Value).HasMaxLength(11).IsRequired();
            c.Property(x => x.Hash);
        });

        builder.OwnsOne(x => x.NIN, c =>
        {
            c.Property(x => x.Value).HasMaxLength(11).IsRequired();
            c.Property(x => x.Hash);
        });

        builder.OwnsOne(x => x.BankAccount, c =>
        {
            c.Property(x => x.AccountNo)
                .HasColumnName("BankAccount_AccountNo")
                //.HasMaxLength(10)
                .IsRequired();
            c.Property(x => x.AccountName)
                .HasColumnName("BankAccount_AccountName")
                //.HasMaxLength(50)
                .IsRequired();
            c.Property(x => x.BVN)
                .HasColumnName("BankAccount_BVN")
                //.HasMaxLength(11)
                .IsRequired();
            c.Property(x => x.BankName)
                .HasColumnName("BankAccount_BankName")
                //.HasMaxLength(50)
                .IsRequired();
        });


        //builder.HasOne(x => x.MemberWallet)
        //    .WithOne(x => x.Member);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.MemberId), "member_memberid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

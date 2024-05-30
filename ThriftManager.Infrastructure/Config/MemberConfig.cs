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


        builder.HasOne(x => x.MemberWallet).WithOne(x => x.Member);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.MemberId), "member_memberid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class ContributionConfig : IEntityTypeConfiguration<Contribution>
{
    public void Configure(EntityTypeBuilder<Contribution> builder)
    {
        builder.ToTable(nameof(Contribution));
        builder.HasKey(x => x.ContributionId);

        builder.OwnsOne(x => x.Timeline, c =>
        {
            c.Property(x => x.Slots).IsRequired();
            c.Property(x => x.Period).IsRequired();
            c.Property(x => x.DueDay).HasMaxLength(11);
        });

        builder.HasOne(x => x.ContributionWallet).WithOne(x => x.Contribution);
        builder.HasMany(x => x.ContributingMembers).WithOne(x => x.Contribution).HasForeignKey(m => m.ContributionId);


        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.ContributionId), "contributionsession_contributionsessionid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

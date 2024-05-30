using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class ContributionSessionConfig : IEntityTypeConfiguration<ContributionSession>
{
    public void Configure(EntityTypeBuilder<ContributionSession> builder)
    {
        builder.ToTable(nameof(ContributionSession));
        builder.HasKey(x => x.ContributionSessionId);

        builder.HasOne(x => x.SessionWallet).WithOne();
        builder.HasMany(x => x.SessionMembers).WithOne().HasForeignKey(m => m.ContributionSessionId);


        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.ContributionSessionId), "contributionsession_contributionsessionid_seq", "ThriftSchema");
    }
}

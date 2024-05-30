using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class GroupConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable(nameof(Group));
        builder.HasKey(x => x.GroupId);

        builder.HasMany(x => x.ContributionSessions).WithOne().HasForeignKey(m => m.GroupId);
        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.GroupId), "group_groupid_seq", "ThriftSchema");
    }
}

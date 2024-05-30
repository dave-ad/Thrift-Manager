using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class ContributingMemberConfig : IEntityTypeConfiguration<ContributingMember>
{
    public void Configure(EntityTypeBuilder<ContributingMember> builder)
    {
        builder.ToTable(nameof(ContributingMember));
        builder.HasKey(x => x.ContributingMemberId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.ContributingMemberId), "sessionmember_sessionmemberid_seq", ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

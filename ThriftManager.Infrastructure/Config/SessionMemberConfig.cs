using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure.Config;

internal class SessionMemberConfig : IEntityTypeConfiguration<SessionMember>
{
    public void Configure(EntityTypeBuilder<SessionMember> builder)
    {
        builder.ToTable(nameof(SessionMember));
        builder.HasKey(x => x.SessionMemberId);

        NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(x => x.SessionMemberId), "sessionmember_sessionmemberid_seq", "ThriftSchema");
    }
}

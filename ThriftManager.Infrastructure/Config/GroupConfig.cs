namespace ThriftManager.Infrastructure.Config;

internal class GroupConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable(nameof(Group));
        builder.HasKey(x => x.GroupId);

        builder.OwnsOne(x => x.Timeline, c =>
        {
            c.Property(x => x.Slots).IsRequired();
            c.Property(x => x.Period).IsRequired();
            c.Property(x => x.DueDay).HasMaxLength(11);
        });

        NpgsqlPropertyBuilderExtensions.UseHiLo
            (builder.Property(x => x.GroupId),
            "group_groupid_seq",
            ThriftAppDbContext.DEFAULT_SCHEMA);
    }
}

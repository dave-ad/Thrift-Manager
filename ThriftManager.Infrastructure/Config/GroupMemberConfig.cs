
//namespace ThriftManager.Infrastructure.Config;

//internal class GroupMemberConfig : IEntityTypeConfiguration<GroupMember>
//{
//    public void Configure(EntityTypeBuilder<GroupMember> builder)
//    {
//        builder.ToTable(nameof(GroupMember));
//        builder.HasKey(x => x.GroupMemberId);
//        builder.HasOne(x => x.Group)
//            .WithMany(g => g.GroupMembers)
//            .HasForeignKey(x => x.GroupId);
//        builder.HasOne(x => x.Member)
//            .WithMany()
//            .HasForeignKey(x => x.MemberId);
//    }
//}

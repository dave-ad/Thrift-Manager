namespace ThriftManager.Infrastructure;

public interface IThriftAppDbContext
{
    DbSet<Member> Members { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<GroupMember> GroupMembers { get; set; }
    DbSet<Contribution> Contributions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}

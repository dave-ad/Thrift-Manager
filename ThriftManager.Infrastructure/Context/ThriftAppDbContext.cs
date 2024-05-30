using Microsoft.EntityFrameworkCore;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure;

internal sealed class ThriftAppDbContext : DbContext, IThriftAppDbContext
{
    private string _schema = "ThriftSchema";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder
     .UseNpgsql("PORT=0000;HOST=0.0.0.0;DATABASE=ThriftAppDB;USER ID=postgres;PASSWORD=;PersistSecurityInfo=true")
     .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThriftAppDbContext).Assembly);
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<MemberWallet> MemberWallets { get; set; }
    public DbSet<MemberWalletTransaction> MemberWalletTransactions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<ContributionSession> ContributionSessions { get; set; }
    public DbSet<SessionMember> SessionMembers { get; set; }
    public DbSet<SessionWallet> SessionWallets { get; set; }
    public DbSet<SessionWalletTransaction> SessionWalletTransactions { get; set; }

}

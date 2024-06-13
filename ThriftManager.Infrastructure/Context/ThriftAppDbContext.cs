using System;

namespace ThriftManager.Infrastructure;

internal sealed class ThriftAppDbContext : DbContext, IThriftAppDbContext
{
    internal const string DEFAULT_SCHEMA = "ThriftSchema";
    private string? DevConnection = "";

    public ThriftAppDbContext()
    {
        DevConnection = "Server=David\\MSSQLSERVER2022;Database=ThriftAppDb;" +
           "initial catalog=ThriftAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;integrated security=True;TrustServerCertificate=True;";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseSqlServer(DevConnection)
        .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThriftAppDbContext).Assembly);

        // Specify column types for decimal properties
        modelBuilder.Entity<Contribution>()
            .Property(c => c.Amount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ContributionWallet>()
            .Property(c => c.Balance)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ContributionWalletTransaction>()
            .Property(c => c.TransactionAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Group>()
            .Property(g => g.Amount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<MemberWallet>()
            .Property(mw => mw.Balance)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<MemberWalletTransaction>()
            .Property(mwt => mwt.TransactionAmount)
            .HasColumnType("decimal(18,2)");
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<MemberWallet> MemberWallets { get; set; }
    public DbSet<MemberWalletTransaction> MemberWalletTransactions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<ContributingMember> ContributingMembers { get; set; }
    public DbSet<ContributionWallet> ContributionWallets { get; set; }
    public DbSet<ContributionWalletTransaction> ContributionWalletTransactions { get; set; }
}
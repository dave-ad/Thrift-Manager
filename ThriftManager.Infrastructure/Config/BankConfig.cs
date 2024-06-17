namespace ThriftManager.Infrastructure.Config;

internal class BankConfig : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.ToTable(nameof(Bank));
        builder.HasKey(x => x.BankId);
        builder.Property(x => x.BankName).HasMaxLength(100).IsRequired();
    }
}

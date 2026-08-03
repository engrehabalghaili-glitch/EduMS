using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DepreciationTransactionConfiguration : IEntityTypeConfiguration<DepreciationTransaction>
{
    public void Configure(EntityTypeBuilder<DepreciationTransaction> builder)
    {
        // Table Name
        builder.ToTable("depreciation_transaction");

        // Property Configurations
        builder.Property(x => x.PeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodEnd)
               .HasMaxLength(100);

        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.DepreciationAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AccumulatedDepreciationAfter)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetBookValueAfter)
               .HasPrecision(18, 2);

        builder.Property(x => x.LedgerEntryReference)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

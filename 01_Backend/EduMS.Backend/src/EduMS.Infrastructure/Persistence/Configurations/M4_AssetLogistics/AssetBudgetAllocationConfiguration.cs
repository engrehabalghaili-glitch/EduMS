using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetBudgetAllocationConfiguration : IEntityTypeConfiguration<AssetBudgetAllocation>
{
    public void Configure(EntityTypeBuilder<AssetBudgetAllocation> builder)
    {
        // Table Name
        builder.ToTable("asset_budget_allocation");

        // Property Configurations
        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.AllocatedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.SpentAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RemainingAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.BudgetLineCode)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

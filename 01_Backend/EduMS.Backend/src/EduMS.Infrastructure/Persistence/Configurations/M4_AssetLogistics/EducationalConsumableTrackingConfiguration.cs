using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EducationalConsumableTrackingConfiguration : IEntityTypeConfiguration<EducationalConsumableTracking>
{
    public void Configure(EntityTypeBuilder<EducationalConsumableTracking> builder)
    {
        // Table Name
        builder.ToTable("educational_consumable_tracking");

        // Property Configurations
        builder.Property(x => x.ConsumableName)
               .HasMaxLength(100);

        builder.Property(x => x.ConsumableCode)
               .HasMaxLength(100);

        builder.Property(x => x.Category)
               .HasMaxLength(100);

        builder.Property(x => x.UnitOfMeasure)
               .HasMaxLength(100);

        builder.Property(x => x.Purpose)
               .HasMaxLength(100);

        builder.Property(x => x.UnitCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.BudgetLineCode)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

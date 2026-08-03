using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolOperationalBudgetLogConfiguration : IEntityTypeConfiguration<SchoolOperationalBudgetLog>
{
    public void Configure(EntityTypeBuilder<SchoolOperationalBudgetLog> builder)
    {
        // Table Name
        builder.ToTable("school_operational_budget_log");

        // Property Configurations
        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.BudgetCategoryCode)
               .HasMaxLength(100);

        builder.Property(x => x.CategoryNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.AllocatedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ConsumedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RemainingAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.CategoryNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.NotesDescription)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

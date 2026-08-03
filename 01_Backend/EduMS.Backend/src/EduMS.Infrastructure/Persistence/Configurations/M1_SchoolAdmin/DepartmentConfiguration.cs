using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Table Name
        builder.ToTable("department");

        // Property Configurations
        builder.Property(x => x.DepartmentCode)
               .HasMaxLength(100);

        builder.Property(x => x.DepartmentNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.DepartmentNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Responsibilities)
               .HasMaxLength(100);

        builder.Property(x => x.AnnualBudget)
               .HasPrecision(18, 2);

        builder.Property(x => x.WorkingHoursDescription)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

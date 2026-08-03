using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeAdditionalTaskConfiguration : IEntityTypeConfiguration<EmployeeAdditionalTask>
{
    public void Configure(EntityTypeBuilder<EmployeeAdditionalTask> builder)
    {
        // Table Name
        builder.ToTable("employee_additional_task");

        // Property Configurations
        builder.Property(x => x.TaskTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TaskDescription)
               .HasMaxLength(500);

        builder.Property(x => x.CompensationAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

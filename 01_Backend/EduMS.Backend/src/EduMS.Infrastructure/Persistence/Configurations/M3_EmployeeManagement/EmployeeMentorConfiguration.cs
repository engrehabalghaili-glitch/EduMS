using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeMentorConfiguration : IEntityTypeConfiguration<EmployeeMentor>
{
    public void Configure(EntityTypeBuilder<EmployeeMentor> builder)
    {
        // Table Name
        builder.ToTable("employee_mentor");

        // Property Configurations
        builder.Property(x => x.MentoringGoals)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

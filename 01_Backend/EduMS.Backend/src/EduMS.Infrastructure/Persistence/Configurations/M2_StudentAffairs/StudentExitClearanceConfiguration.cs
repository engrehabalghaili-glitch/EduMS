using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentExitClearanceConfiguration : IEntityTypeConfiguration<StudentExitClearance>
{
    public void Configure(EntityTypeBuilder<StudentExitClearance> builder)
    {
        // Table Name
        builder.ToTable("student_exit_clearance");

        // Property Configurations
        builder.Property(x => x.ClearanceReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ClearanceNotes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

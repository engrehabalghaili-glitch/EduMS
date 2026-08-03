using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyEmployeeSafetyRecordConfiguration : IEntityTypeConfiguration<EmergencyEmployeeSafetyRecord>
{
    public void Configure(EntityTypeBuilder<EmergencyEmployeeSafetyRecord> builder)
    {
        // Table Name
        builder.ToTable("emergency_employee_safety_record");

        // Property Configurations
        builder.Property(x => x.AssignedRole)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

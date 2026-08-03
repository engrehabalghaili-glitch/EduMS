using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FacilityDepartmentAssignmentConfiguration : IEntityTypeConfiguration<FacilityDepartmentAssignment>
{
    public void Configure(EntityTypeBuilder<FacilityDepartmentAssignment> builder)
    {
        // Table Name
        builder.ToTable("facility_department_assignment");

        // Property Configurations
        builder.Property(x => x.SharedWithDepartmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.SharingScheduleJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

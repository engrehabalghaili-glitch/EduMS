using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolFacilityMaintenanceLogConfiguration : IEntityTypeConfiguration<SchoolFacilityMaintenanceLog>
{
    public void Configure(EntityTypeBuilder<SchoolFacilityMaintenanceLog> builder)
    {
        // Table Name
        builder.ToTable("school_facility_maintenance_log");

        // Property Configurations
        builder.Property(x => x.MaintenanceCode)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionDetails)
               .HasMaxLength(500);

        builder.Property(x => x.TotalCostAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExternalContractorName)
               .HasMaxLength(100);

        builder.Property(x => x.InspectionRemarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

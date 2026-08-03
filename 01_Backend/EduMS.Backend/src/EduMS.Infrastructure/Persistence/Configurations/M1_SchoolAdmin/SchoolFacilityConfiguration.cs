using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolFacilityConfiguration : IEntityTypeConfiguration<SchoolFacility>
{
    public void Configure(EntityTypeBuilder<SchoolFacility> builder)
    {
        // Table Name
        builder.ToTable("school_facility");

        // Property Configurations
        builder.Property(x => x.FacilityCode)
               .HasMaxLength(100);

        builder.Property(x => x.FacilityNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FacilityNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.LocationFloor)
               .HasMaxLength(100);

        builder.Property(x => x.BuildingName)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

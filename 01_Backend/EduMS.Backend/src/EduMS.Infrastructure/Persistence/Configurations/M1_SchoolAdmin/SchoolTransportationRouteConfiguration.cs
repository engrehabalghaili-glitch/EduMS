using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolTransportationRouteConfiguration : IEntityTypeConfiguration<SchoolTransportationRoute>
{
    public void Configure(EntityTypeBuilder<SchoolTransportationRoute> builder)
    {
        // Table Name
        builder.ToTable("school_transportation_route");

        // Property Configurations
        builder.Property(x => x.RouteCode)
               .HasMaxLength(100);

        builder.Property(x => x.RouteNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.BusPlateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.MorningStartHour)
               .HasMaxLength(100);

        builder.Property(x => x.EveningReturnHour)
               .HasMaxLength(100);

        builder.Property(x => x.MonthlyFee)
               .HasPrecision(18, 2);

        builder.Property(x => x.RouteNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.BusModelAndYear)
               .HasMaxLength(100);

        builder.Property(x => x.GpsTrackingDeviceId)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class TransportationServiceConfiguration : IEntityTypeConfiguration<TransportationService>
{
    public void Configure(EntityTypeBuilder<TransportationService> builder)
    {
        // Table Name
        builder.ToTable("transportation_service");

        // Property Configurations
        builder.Property(x => x.RouteCode)
               .HasMaxLength(100);

        builder.Property(x => x.RouteName)
               .HasMaxLength(100);

        builder.Property(x => x.RouteDescription)
               .HasMaxLength(500);

        builder.Property(x => x.BusPlateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.BusModel)
               .HasMaxLength(100);

        builder.Property(x => x.BusYear)
               .HasMaxLength(100);

        builder.Property(x => x.DriverLicenseNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DriverPhone)
               .HasMaxLength(100);

        builder.Property(x => x.SupervisorPhone)
               .HasMaxLength(100);

        builder.Property(x => x.StartTime)
               .HasMaxLength(100);

        builder.Property(x => x.EndTime)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedDurationMinutes)
               .HasMaxLength(100);

        builder.Property(x => x.StopsJson)
               .HasMaxLength(100);

        builder.Property(x => x.OperatorCompany)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

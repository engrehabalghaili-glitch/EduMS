using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentTransportationSubscriptionConfiguration : IEntityTypeConfiguration<StudentTransportationSubscription>
{
    public void Configure(EntityTypeBuilder<StudentTransportationSubscription> builder)
    {
        // Table Name
        builder.ToTable("student_transportation_subscription");

        // Property Configurations
        builder.Property(x => x.PickupStationAddress)
               .HasMaxLength(500);

        builder.Property(x => x.DropoffStationAddress)
               .HasMaxLength(500);

        builder.Property(x => x.AgreedMonthlyFee)
               .HasPrecision(18, 2);

        builder.Property(x => x.PickupTime)
               .HasMaxLength(100);

        builder.Property(x => x.DropoffTime)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

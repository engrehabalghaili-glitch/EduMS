using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentTransportPreferenceConfiguration : IEntityTypeConfiguration<StudentTransportPreference>
{
    public void Configure(EntityTypeBuilder<StudentTransportPreference> builder)
    {
        // Table Name
        builder.ToTable("student_transport_preference");

        // Property Configurations
        builder.Property(x => x.PickupAddress)
               .HasMaxLength(500);

        builder.Property(x => x.PickupGpsLatitude)
               .HasMaxLength(100);

        builder.Property(x => x.PickupGpsLongitude)
               .HasMaxLength(100);

        builder.Property(x => x.PreferredPickupTime)
               .HasMaxLength(100);

        builder.Property(x => x.PreferredDropoffTime)
               .HasMaxLength(100);

        builder.Property(x => x.WeeklyDaysJson)
               .HasMaxLength(100);

        builder.Property(x => x.EscortName)
               .HasMaxLength(100);

        builder.Property(x => x.EscortPhone)
               .HasMaxLength(100);

        builder.Property(x => x.EscortRelationToStudent)
               .HasMaxLength(100);

        builder.Property(x => x.SpecialNeedsTransportDetails)
               .HasMaxLength(100);

        builder.Property(x => x.SubscriptionFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TransportContractFileUrl)
               .HasMaxLength(100);

        builder.Property(x => x.AuthorizedPickupPersonsJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

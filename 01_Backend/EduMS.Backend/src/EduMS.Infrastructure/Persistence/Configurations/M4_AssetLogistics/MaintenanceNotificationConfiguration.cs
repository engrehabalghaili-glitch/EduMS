using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class MaintenanceNotificationConfiguration : IEntityTypeConfiguration<MaintenanceNotification>
{
    public void Configure(EntityTypeBuilder<MaintenanceNotification> builder)
    {
        // Table Name
        builder.ToTable("maintenance_notification");

        // Property Configurations
        builder.Property(x => x.RelatedEntityType)
               .HasMaxLength(100);

        builder.Property(x => x.Title)
               .HasMaxLength(100);

        builder.Property(x => x.MessageContent)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

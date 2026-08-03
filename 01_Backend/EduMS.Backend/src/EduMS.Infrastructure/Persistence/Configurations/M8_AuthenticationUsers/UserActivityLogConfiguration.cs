using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class UserActivityLogConfiguration : IEntityTypeConfiguration<UserActivityLog>
{
    public void Configure(EntityTypeBuilder<UserActivityLog> builder)
    {
        // Table Name
        builder.ToTable("user_activity_log");

        // Property Configurations
        builder.Property(x => x.ActivityType)
               .HasMaxLength(100);

        builder.Property(x => x.FailureReason)
               .HasMaxLength(500);

        builder.Property(x => x.IpAddress)
               .HasMaxLength(500);

        builder.Property(x => x.DeviceType)
               .HasMaxLength(100);

        builder.Property(x => x.DeviceName)
               .HasMaxLength(100);

        builder.Property(x => x.OperatingSystem)
               .HasMaxLength(100);

        builder.Property(x => x.Browser)
               .HasMaxLength(100);

        builder.Property(x => x.UserAgent)
               .HasMaxLength(100);

        builder.Property(x => x.LocationText)
               .HasMaxLength(100);

        builder.Property(x => x.SessionId)
               .HasMaxLength(100);

        builder.Property(x => x.ActionDetailsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

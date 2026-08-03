using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SystemAuditLogConfiguration : IEntityTypeConfiguration<SystemAuditLog>
{
    public void Configure(EntityTypeBuilder<SystemAuditLog> builder)
    {
        // Table Name
        builder.ToTable("system_audit_log");

        // Property Configurations
        builder.Property(x => x.UserRoleAtExecution)
               .HasMaxLength(100);

        builder.Property(x => x.ActionType)
               .HasMaxLength(100);

        builder.Property(x => x.EntityType)
               .HasMaxLength(100);

        builder.Property(x => x.OldValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.NewValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.ChangeSummary)
               .HasMaxLength(100);

        builder.Property(x => x.TableName)
               .HasMaxLength(100);

        builder.Property(x => x.FieldName)
               .HasMaxLength(100);

        builder.Property(x => x.IpAddress)
               .HasMaxLength(500);

        builder.Property(x => x.DeviceType)
               .HasMaxLength(100);

        builder.Property(x => x.UserAgent)
               .HasMaxLength(100);

        builder.Property(x => x.SessionId)
               .HasMaxLength(100);

        builder.Property(x => x.AccessContextJson)
               .HasMaxLength(100);

        builder.Property(x => x.Severity)
               .HasMaxLength(100);

        builder.Property(x => x.RiskScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

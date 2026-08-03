using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAuditLogConfiguration : IEntityTypeConfiguration<SchoolAuditLog>
{
    public void Configure(EntityTypeBuilder<SchoolAuditLog> builder)
    {
        // Table Name
        builder.ToTable("school_audit_log");

        // Property Configurations
        builder.Property(x => x.AffectedTableName)
               .HasMaxLength(100);

        builder.Property(x => x.ChangeTypeSummary)
               .HasMaxLength(100);

        builder.Property(x => x.OldValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.NewValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.ChangeSummaryText)
               .HasMaxLength(100);

        builder.Property(x => x.PerformedByUserName)
               .HasMaxLength(100);

        builder.Property(x => x.PerformedByUserRole)
               .HasMaxLength(100);

        builder.Property(x => x.IpAddress)
               .HasMaxLength(500);

        builder.Property(x => x.DeviceInfo)
               .HasMaxLength(100);

        builder.Property(x => x.DecisionDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

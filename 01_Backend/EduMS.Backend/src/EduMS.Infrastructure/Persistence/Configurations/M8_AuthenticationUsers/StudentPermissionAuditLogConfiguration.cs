using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentPermissionAuditLogConfiguration : IEntityTypeConfiguration<StudentPermissionAuditLog>
{
    public void Configure(EntityTypeBuilder<StudentPermissionAuditLog> builder)
    {
        // Table Name
        builder.ToTable("student_permission_audit_log");

        // Property Configurations
        builder.Property(x => x.UserRole)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionKey)
               .HasMaxLength(100);

        builder.Property(x => x.EntityType)
               .HasMaxLength(100);

        builder.Property(x => x.ActionType)
               .HasMaxLength(100);

        builder.Property(x => x.AccessContextJson)
               .HasMaxLength(100);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.RiskScore)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

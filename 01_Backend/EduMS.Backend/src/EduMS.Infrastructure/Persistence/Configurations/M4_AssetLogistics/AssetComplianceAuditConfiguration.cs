using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetComplianceAuditConfiguration : IEntityTypeConfiguration<AssetComplianceAudit>
{
    public void Configure(EntityTypeBuilder<AssetComplianceAudit> builder)
    {
        // Table Name
        builder.ToTable("asset_compliance_audit");

        // Property Configurations
        builder.Property(x => x.AuditNumber)
               .HasMaxLength(100);

        builder.Property(x => x.StandardType)
               .HasMaxLength(100);

        builder.Property(x => x.AuditScope)
               .HasMaxLength(100);

        builder.Property(x => x.ComplianceScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.ViolationsFoundJson)
               .HasMaxLength(100);

        builder.Property(x => x.CorrectiveActionsRequired)
               .HasMaxLength(100);

        builder.Property(x => x.CorrectiveActionsDeadline)
               .HasMaxLength(100);

        builder.Property(x => x.AuditReportUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

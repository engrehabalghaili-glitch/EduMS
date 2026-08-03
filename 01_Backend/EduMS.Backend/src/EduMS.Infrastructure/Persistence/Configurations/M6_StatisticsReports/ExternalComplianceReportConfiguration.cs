using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ExternalComplianceReportConfiguration : IEntityTypeConfiguration<ExternalComplianceReport>
{
    public void Configure(EntityTypeBuilder<ExternalComplianceReport> builder)
    {
        // Table Name
        builder.ToTable("EXTERNAL_COMPLIANCE_REPORT");

        // Property Configurations
        builder.Property(x => x.ReportNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TargetEntityName)
               .HasMaxLength(100);

        builder.Property(x => x.StandardType)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodEnd)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.ReceiptReference)
               .HasMaxLength(100);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}



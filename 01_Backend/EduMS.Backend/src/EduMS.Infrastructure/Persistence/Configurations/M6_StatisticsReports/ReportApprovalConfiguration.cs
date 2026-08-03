using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ReportApprovalConfiguration : IEntityTypeConfiguration<ReportApproval>
{
    public void Configure(EntityTypeBuilder<ReportApproval> builder)
    {
        // Table Name
        builder.ToTable("REPORT_APPROVAL");

        // Property Configurations
        builder.Property(x => x.Comments)
               .HasMaxLength(100);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.DigitalSignatureHash)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.CertificatePath)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}



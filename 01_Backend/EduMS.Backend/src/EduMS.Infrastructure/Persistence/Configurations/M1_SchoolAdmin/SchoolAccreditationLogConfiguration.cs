using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAccreditationLogConfiguration : IEntityTypeConfiguration<SchoolAccreditationLog>
{
    public void Configure(EntityTypeBuilder<SchoolAccreditationLog> builder)
    {
        // Table Name
        builder.ToTable("school_accreditation_log");

        // Property Configurations
        builder.Property(x => x.LicenseNumber)
               .HasMaxLength(100);

        builder.Property(x => x.AccreditationBody)
               .HasMaxLength(100);

        builder.Property(x => x.AccreditationGrade)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateAttachmentUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
{
    public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
    {
        // Table Name
        builder.ToTable("employee_document");

        // Property Configurations
        builder.Property(x => x.DocumentType)
               .HasMaxLength(100);

        builder.Property(x => x.DocumentSubType)
               .HasMaxLength(100);

        builder.Property(x => x.DocumentName)
               .HasMaxLength(100);

        builder.Property(x => x.DocumentNumber)
               .HasMaxLength(100);

        builder.Property(x => x.IssuedBy)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.FileType)
               .HasMaxLength(100);

        builder.Property(x => x.ThumbnailPath)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.VerificationNotes)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

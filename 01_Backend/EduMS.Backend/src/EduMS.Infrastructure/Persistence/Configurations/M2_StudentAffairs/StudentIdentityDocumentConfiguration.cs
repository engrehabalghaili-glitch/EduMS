using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentIdentityDocumentConfiguration : IEntityTypeConfiguration<StudentIdentityDocument>
{
    public void Configure(EntityTypeBuilder<StudentIdentityDocument> builder)
    {
        // Table Name
        builder.ToTable("student_identity_document");

        // Property Configurations
        builder.Property(x => x.DocumentNumber)
               .HasMaxLength(100);

        builder.Property(x => x.IssueCountry)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.IssuePlace)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

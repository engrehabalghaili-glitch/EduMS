using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAttachmentConfiguration : IEntityTypeConfiguration<StudentAttachment>
{
    public void Configure(EntityTypeBuilder<StudentAttachment> builder)
    {
        // Table Name
        builder.ToTable("student_attachment");

        // Property Configurations
        builder.Property(x => x.AttachmentTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.FileName)
               .HasMaxLength(100);

        builder.Property(x => x.FilePathUrl)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.MimeType)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentExemplaryRecognitionConfiguration : IEntityTypeConfiguration<StudentExemplaryRecognition>
{
    public void Configure(EntityTypeBuilder<StudentExemplaryRecognition> builder)
    {
        // Table Name
        builder.ToTable("student_exemplary_recognition");

        // Property Configurations
        builder.Property(x => x.AcademicYear)
               .HasMaxLength(100);

        builder.Property(x => x.RecognitionTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.RecognitionTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.AwardGrantedBy)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class JobApplicantConfiguration : IEntityTypeConfiguration<JobApplicant>
{
    public void Configure(EntityTypeBuilder<JobApplicant> builder)
    {
        // Table Name
        builder.ToTable("job_applicant");

        // Property Configurations
        builder.Property(x => x.ApplicantFullNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFullNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.NationalIdNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PhonePrimary)
               .HasMaxLength(100);

        builder.Property(x => x.EmailAddress)
               .HasMaxLength(500);

        builder.Property(x => x.AcademicQualification)
               .HasMaxLength(100);

        builder.Property(x => x.QualificationSource)
               .HasMaxLength(100);

        builder.Property(x => x.CvDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.CoverLetterUrl)
               .HasMaxLength(100);

        builder.Property(x => x.InterviewNotes)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

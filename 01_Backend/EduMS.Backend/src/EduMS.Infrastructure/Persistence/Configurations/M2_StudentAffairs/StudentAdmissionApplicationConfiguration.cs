using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAdmissionApplicationConfiguration : IEntityTypeConfiguration<StudentAdmissionApplication>
{
    public void Configure(EntityTypeBuilder<StudentAdmissionApplication> builder)
    {
        // Table Name
        builder.ToTable("student_admission_application");

        // Property Configurations
        builder.Property(x => x.ApplicantFirstNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFatherNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantGrandfatherNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFamilyNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFirstNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFatherNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantGrandfatherNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantFamilyNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantNationalId)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantBirthPlace)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantNationality)
               .HasMaxLength(100);

        builder.Property(x => x.ApplicantAddress)
               .HasMaxLength(500);

        builder.Property(x => x.RequestedGradeLevelCode)
               .HasMaxLength(100);

        builder.Property(x => x.BirthCertificateAttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.PersonalPhotoAttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.IDCardImageAttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.PreviousSchoolName)
               .HasMaxLength(100);

        builder.Property(x => x.PreviousSchoolGradeLevel)
               .HasMaxLength(100);

        builder.Property(x => x.SpecialNeedsDetails)
               .HasMaxLength(100);

        builder.Property(x => x.MedicalNotes)
               .HasMaxLength(500);

        builder.Property(x => x.SiblingNames)
               .HasMaxLength(100);

        builder.Property(x => x.ReferralSource)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactName)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

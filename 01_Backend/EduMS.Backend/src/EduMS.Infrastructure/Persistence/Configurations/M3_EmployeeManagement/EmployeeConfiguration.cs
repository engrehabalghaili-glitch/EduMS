using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Table Name
        builder.ToTable("employee");

        // Property Configurations
        builder.Property(x => x.EmployeeCode)
               .HasMaxLength(100);

        builder.Property(x => x.NationalIdNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ResidenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ResidenceSponsorName)
               .HasMaxLength(100);

        builder.Property(x => x.FirstNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FatherNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.GrandfatherNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FamilyNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FirstNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.FamilyNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Nationality)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactName)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.BloodType)
               .HasMaxLength(100);

        builder.Property(x => x.PhonePrimary)
               .HasMaxLength(100);

        builder.Property(x => x.PhoneSecondary)
               .HasMaxLength(100);

        builder.Property(x => x.PersonalEmail)
               .HasMaxLength(100);

        builder.Property(x => x.OfficialEmail)
               .HasMaxLength(100);

        builder.Property(x => x.FullAddress)
               .HasMaxLength(500);

        builder.Property(x => x.City)
               .HasMaxLength(100);

        builder.Property(x => x.ProfilePhotoUrl)
               .HasMaxLength(100);

        builder.Property(x => x.JobTitle)
               .HasMaxLength(100);

        builder.Property(x => x.JobGrade)
               .HasMaxLength(100);

        builder.Property(x => x.Specialization)
               .HasMaxLength(100);

        builder.Property(x => x.AcademicQualification)
               .HasMaxLength(100);

        builder.Property(x => x.QualificationSource)
               .HasMaxLength(100);

        builder.Property(x => x.PortalUsername)
               .HasMaxLength(100);

        builder.Property(x => x.PortalPasswordHash)
               .HasMaxLength(100);

        builder.Property(x => x.BankName)
               .HasMaxLength(100);

        builder.Property(x => x.BankIban)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

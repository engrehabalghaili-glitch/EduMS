using EduMS.Domain.Entities.M2_StudentAffairs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M2_StudentAffairs.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable("Registrations");

        builder.HasKey(r => r.Id);

        // Required Properties
        builder.Property(r => r.FirstNameAr).IsRequired().HasMaxLength(50);
        builder.Property(r => r.FatherNameAr).IsRequired().HasMaxLength(50);
        builder.Property(r => r.FamilyNameAr).IsRequired().HasMaxLength(50);
        
        builder.Property(r => r.Gender).IsRequired();
        builder.Property(r => r.RequestStatus).IsRequired();
        builder.Property(r => r.SubmissionDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Check Constraints
        builder.ToTable(t => t.HasCheckConstraint("CK_Registration_Gender", "\"Gender\" IN (1, 2)"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Registration_Status", "\"RequestStatus\" IN (1, 2, 3, 4)"));

        // Indexes
        builder.HasIndex(r => r.ParentId);
        builder.HasIndex(r => r.SchoolId);
        builder.HasIndex(r => new { r.ParentId, r.SchoolId, r.AcademicYearId, r.RequestedGradeLevelId }).IsUnique().HasFilter("RequestStatus != 3"); // Prevent duplicate pending/accepted applications
    }
}

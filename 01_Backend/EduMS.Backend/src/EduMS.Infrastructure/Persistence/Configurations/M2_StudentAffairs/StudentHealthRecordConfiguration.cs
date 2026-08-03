using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentHealthRecordConfiguration : IEntityTypeConfiguration<StudentHealthRecord>
{
    public void Configure(EntityTypeBuilder<StudentHealthRecord> builder)
    {
        // Table Name
        builder.ToTable("student_health_record");

        // Property Configurations
        builder.Property(x => x.ExaminationDetails)
               .HasMaxLength(100);

        builder.Property(x => x.Diagnosis)
               .HasMaxLength(100);

        builder.Property(x => x.TreatmentPlan)
               .HasMaxLength(100);

        builder.Property(x => x.ReferralHospital)
               .HasMaxLength(100);

        builder.Property(x => x.ExaminedByNurseName)
               .HasMaxLength(100);

        builder.Property(x => x.HealthRecordCode)
               .HasMaxLength(100);

        builder.Property(x => x.PhysicalHeightCm)
               .HasPrecision(18, 2);

        builder.Property(x => x.PhysicalWeightKg)
               .HasPrecision(18, 2);

        builder.Property(x => x.VisionCheckResult)
               .HasMaxLength(100);

        builder.Property(x => x.HearingCheckResult)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

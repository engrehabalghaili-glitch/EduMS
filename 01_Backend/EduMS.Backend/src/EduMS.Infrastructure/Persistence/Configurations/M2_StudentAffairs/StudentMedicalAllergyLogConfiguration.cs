using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentMedicalAllergyLogConfiguration : IEntityTypeConfiguration<StudentMedicalAllergyLog>
{
    public void Configure(EntityTypeBuilder<StudentMedicalAllergyLog> builder)
    {
        // Table Name
        builder.ToTable("student_medical_allergy_log");

        // Property Configurations
        builder.Property(x => x.AllergyOrConditionName)
               .HasMaxLength(100);

        builder.Property(x => x.ReactionSymptoms)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyActionProtocol)
               .HasMaxLength(100);

        builder.Property(x => x.RequiredMedicationName)
               .HasMaxLength(100);

        builder.Property(x => x.DoctorContactNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

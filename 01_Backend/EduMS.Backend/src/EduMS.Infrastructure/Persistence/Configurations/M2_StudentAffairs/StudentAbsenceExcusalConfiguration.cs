using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAbsenceExcusalConfiguration : IEntityTypeConfiguration<StudentAbsenceExcusal>
{
    public void Configure(EntityTypeBuilder<StudentAbsenceExcusal> builder)
    {
        // Table Name
        builder.ToTable("student_absence_excusal");

        // Property Configurations
        builder.Property(x => x.ReasonDescription)
               .HasMaxLength(500);

        builder.Property(x => x.MedicalReportAttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.ReviewRemarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

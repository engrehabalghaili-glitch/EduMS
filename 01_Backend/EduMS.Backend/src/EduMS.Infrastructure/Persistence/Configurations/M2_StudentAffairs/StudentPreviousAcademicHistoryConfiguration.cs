using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentPreviousAcademicHistoryConfiguration : IEntityTypeConfiguration<StudentPreviousAcademicHistory>
{
    public void Configure(EntityTypeBuilder<StudentPreviousAcademicHistory> builder)
    {
        // Table Name
        builder.ToTable("student_previous_academic_history");

        // Property Configurations
        builder.Property(x => x.PreviousSchoolName)
               .HasMaxLength(100);

        builder.Property(x => x.PreviousDirectorateName)
               .HasMaxLength(100);

        builder.Property(x => x.AcademicYearCompleted)
               .HasMaxLength(100);

        builder.Property(x => x.CumulativeScoreEarned)
               .HasPrecision(18, 2);

        builder.Property(x => x.MaximumPossibleScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.PercentagePercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.LeavingCertificateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TranscriptDocumentUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

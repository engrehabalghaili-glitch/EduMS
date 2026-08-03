using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SubmittedStatisticsConfiguration : IEntityTypeConfiguration<SubmittedStatistics>
{
    public void Configure(EntityTypeBuilder<SubmittedStatistics> builder)
    {
        // Table Name
        builder.ToTable("SUBMITTED_STATISTICS");

        // Property Configurations
        builder.Property(x => x.SubmissionNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DirectorSignatureHash)
               .HasMaxLength(100);

        builder.Property(x => x.StudentDataSnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.StaffDataSnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.FinancialSummarySnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.ReviewerNotes)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}



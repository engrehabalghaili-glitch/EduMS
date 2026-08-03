using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class OfficeReportSubmissionConfiguration : IEntityTypeConfiguration<OfficeReportSubmission>
{
    public void Configure(EntityTypeBuilder<OfficeReportSubmission> builder)
    {
        builder.ToTable("OFFICE_REPORT_SUBMISSION");

        builder.Property(x => x.ReportTitle).HasMaxLength(500).IsRequired();
        builder.Property(x => x.PeriodLabel).HasMaxLength(200).IsRequired();
        builder.Property(x => x.RecipientEntityName).HasMaxLength(300);
        builder.Property(x => x.FilePath).HasMaxLength(500);
        builder.Property(x => x.FileFormat).HasMaxLength(10);
        builder.Property(x => x.DirectorSignatureHash).HasMaxLength(500);
        builder.Property(x => x.ReceiptReference).HasMaxLength(200);
        builder.Property(x => x.RejectionReason).HasMaxLength(1000);
        builder.Property(x => x.ReviewerNotes).HasMaxLength(1000);
        builder.Property(x => x.Notes).HasMaxLength(1000);

        builder.HasOne(x => x.Directorate)
               .WithMany()
               .HasForeignKey(x => x.DirectorateId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DirectorateSnapshot)
               .WithMany()
               .HasForeignKey(x => x.DirectorateSnapshotId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

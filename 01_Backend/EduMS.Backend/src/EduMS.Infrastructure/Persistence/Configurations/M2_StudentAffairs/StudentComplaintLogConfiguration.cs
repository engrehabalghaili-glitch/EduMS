using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentComplaintLogConfiguration : IEntityTypeConfiguration<StudentComplaintLog>
{
    public void Configure(EntityTypeBuilder<StudentComplaintLog> builder)
    {
        // Table Name
        builder.ToTable("student_complaint_log");

        // Property Configurations
        builder.Property(x => x.ComplaintReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ComplaintTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.ComplaintDescriptionText)
               .HasMaxLength(500);

        builder.Property(x => x.SupportingDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.InvestigationNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ResolutionDecisionText)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

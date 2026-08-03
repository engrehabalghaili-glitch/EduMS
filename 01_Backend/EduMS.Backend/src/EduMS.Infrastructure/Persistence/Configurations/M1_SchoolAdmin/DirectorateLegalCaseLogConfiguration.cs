using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DirectorateLegalCaseLogConfiguration : IEntityTypeConfiguration<DirectorateLegalCaseLog>
{
    public void Configure(EntityTypeBuilder<DirectorateLegalCaseLog> builder)
    {
        // Table Name
        builder.ToTable("directorate_legal_case_log");

        // Property Configurations
        builder.Property(x => x.CaseCodeNumber)
               .HasMaxLength(100);

        builder.Property(x => x.SubjectTitle)
               .HasMaxLength(100);

        builder.Property(x => x.InvolvedPartiesDescription)
               .HasMaxLength(500);

        builder.Property(x => x.ResolutionDecisionText)
               .HasMaxLength(100);

        builder.Property(x => x.CaseDocumentAttachmentUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

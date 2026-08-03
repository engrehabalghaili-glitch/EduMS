using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolMergerConfiguration : IEntityTypeConfiguration<SchoolMerger>
{
    public void Configure(EntityTypeBuilder<SchoolMerger> builder)
    {
        // Table Name
        builder.ToTable("school_merger");

        // Property Configurations
        builder.Property(x => x.MergerNumber)
               .HasMaxLength(100);

        builder.Property(x => x.SourceSchoolIdsJson)
               .HasMaxLength(100);

        builder.Property(x => x.MergerReason)
               .HasMaxLength(500);

        builder.Property(x => x.DecisionAuthority)
               .HasMaxLength(100);

        builder.Property(x => x.DecisionDocumentPath)
               .HasMaxLength(100);

        builder.Property(x => x.CompletionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

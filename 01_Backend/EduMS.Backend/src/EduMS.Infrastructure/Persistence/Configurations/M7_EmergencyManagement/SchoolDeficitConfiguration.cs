using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolDeficitConfiguration : IEntityTypeConfiguration<SchoolDeficit>
{
    public void Configure(EntityTypeBuilder<SchoolDeficit> builder)
    {
        // Table Name
        builder.ToTable("school_deficit");

        // Property Configurations
        builder.Property(x => x.DeficitNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DeficitType)
               .HasMaxLength(100);

        builder.Property(x => x.DeficitCategory)
               .HasMaxLength(100);

        builder.Property(x => x.DeficitAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RequiredAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AvailableAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.DeficitDescription)
               .HasMaxLength(500);

        builder.Property(x => x.EducationalImpact)
               .HasMaxLength(100);

        builder.Property(x => x.ProposedSolution)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedResolutionCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.ResolutionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

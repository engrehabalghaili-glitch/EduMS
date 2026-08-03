using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolSurplusConfiguration : IEntityTypeConfiguration<SchoolSurplus>
{
    public void Configure(EntityTypeBuilder<SchoolSurplus> builder)
    {
        // Table Name
        builder.ToTable("school_surplus");

        // Property Configurations
        builder.Property(x => x.SurplusNumber)
               .HasMaxLength(100);

        builder.Property(x => x.SurplusType)
               .HasMaxLength(100);

        builder.Property(x => x.SurplusCategory)
               .HasMaxLength(100);

        builder.Property(x => x.SurplusAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AvailableAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RequiredAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.SurplusDescription)
               .HasMaxLength(500);

        builder.Property(x => x.UtilizationPlan)
               .HasMaxLength(100);

        builder.Property(x => x.UtilizationType)
               .HasMaxLength(100);

        builder.Property(x => x.PotentialBeneficiary)
               .HasMaxLength(100);

        builder.Property(x => x.UtilizationNotes)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

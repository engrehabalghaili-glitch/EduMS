using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetTechnicalSpecificationConfiguration : IEntityTypeConfiguration<AssetTechnicalSpecification>
{
    public void Configure(EntityTypeBuilder<AssetTechnicalSpecification> builder)
    {
        // Table Name
        builder.ToTable("asset_technical_specification");

        // Property Configurations
        builder.Property(x => x.SpecCode)
               .HasMaxLength(100);

        builder.Property(x => x.SpecNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SpecNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.AssetTypeDescription)
               .HasMaxLength(500);

        builder.Property(x => x.TechnicalDetailsJson)
               .HasMaxLength(100);

        builder.Property(x => x.RequiredCertifications)
               .HasMaxLength(100);

        builder.Property(x => x.AcceptanceCriteria)
               .HasMaxLength(100);

        builder.Property(x => x.QualityStandards)
               .HasMaxLength(100);

        builder.Property(x => x.WarrantyRequirements)
               .HasMaxLength(100);

        builder.Property(x => x.SafetyRequirements)
               .HasMaxLength(100);

        builder.Property(x => x.SpecVersion)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

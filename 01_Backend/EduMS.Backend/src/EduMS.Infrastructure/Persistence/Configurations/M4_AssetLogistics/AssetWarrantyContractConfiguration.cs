using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetWarrantyContractConfiguration : IEntityTypeConfiguration<AssetWarrantyContract>
{
    public void Configure(EntityTypeBuilder<AssetWarrantyContract> builder)
    {
        // Table Name
        builder.ToTable("asset_warranty_contract");

        // Property Configurations
        builder.Property(x => x.ContractNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ContractName)
               .HasMaxLength(100);

        builder.Property(x => x.ProviderName)
               .HasMaxLength(100);

        builder.Property(x => x.ProviderContact)
               .HasMaxLength(100);

        builder.Property(x => x.CoverageDetailsText)
               .HasMaxLength(100);

        builder.Property(x => x.ContractValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.RenewalTerms)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFinancialsConfiguration : IEntityTypeConfiguration<AssetFinancials>
{
    public void Configure(EntityTypeBuilder<AssetFinancials> builder)
    {
        // Table Name
        builder.ToTable("asset_financials");

        // Property Configurations
        builder.Property(x => x.PurchasePrice)
               .HasPrecision(18, 2);

        builder.Property(x => x.ShippingCosts)
               .HasPrecision(18, 2);

        builder.Property(x => x.CustomsFees)
               .HasPrecision(18, 2);

        builder.Property(x => x.InstallationCosts)
               .HasPrecision(18, 2);

        builder.Property(x => x.OtherCosts)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalInitialCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.ExchangeRateToSar)
               .HasPrecision(18, 2);

        builder.Property(x => x.SalvageValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

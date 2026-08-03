using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFinancialJournalLinkConfiguration : IEntityTypeConfiguration<AssetFinancialJournalLink>
{
    public void Configure(EntityTypeBuilder<AssetFinancialJournalLink> builder)
    {
        // Table Name
        builder.ToTable("asset_financial_journal_link");

        // Property Configurations
        builder.Property(x => x.EntryType)
               .HasMaxLength(100);

        builder.Property(x => x.EntryAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

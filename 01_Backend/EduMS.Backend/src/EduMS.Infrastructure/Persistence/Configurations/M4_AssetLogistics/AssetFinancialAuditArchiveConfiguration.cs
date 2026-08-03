using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFinancialAuditArchiveConfiguration : IEntityTypeConfiguration<AssetFinancialAuditArchive>
{
    public void Configure(EntityTypeBuilder<AssetFinancialAuditArchive> builder)
    {
        // Table Name
        builder.ToTable("asset_financial_audit_archive");

        // Property Configurations
        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodEnd)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAssetsValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDepreciationValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.ReportFileUrl)
               .HasMaxLength(100);

        builder.Property(x => x.AuditStatus)
               .HasMaxLength(100);

        builder.Property(x => x.AuditFirmName)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFinancialSummaryReportConfiguration : IEntityTypeConfiguration<AssetFinancialSummaryReport>
{
    public void Configure(EntityTypeBuilder<AssetFinancialSummaryReport> builder)
    {
        // Table Name
        builder.ToTable("asset_financial_summary_report");

        // Property Configurations
        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.ReportType)
               .HasMaxLength(100);

        builder.Property(x => x.TotalBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDepreciation)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalAssetsCount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalAcquisitionCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.RevaluationGains)
               .HasMaxLength(100);

        builder.Property(x => x.RevaluationLosses)
               .HasMaxLength(100);

        builder.Property(x => x.AuditStatus)
               .HasMaxLength(100);

        builder.Property(x => x.AuditFirmName)
               .HasMaxLength(100);

        builder.Property(x => x.AuditorName)
               .HasMaxLength(100);

        builder.Property(x => x.AuditorSignature)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}

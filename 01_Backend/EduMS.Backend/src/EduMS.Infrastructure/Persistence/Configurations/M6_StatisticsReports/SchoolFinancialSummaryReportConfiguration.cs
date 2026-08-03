using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolFinancialSummaryReportConfiguration : IEntityTypeConfiguration<SchoolFinancialSummaryReport>
{
    public void Configure(EntityTypeBuilder<SchoolFinancialSummaryReport> builder)
    {
        // Table Name
        builder.ToView("SCHOOL_FINANCIAL_SUMMARY_VIEW");

        // Property Configurations
        builder.Property(x => x.FiscalYear)
               .HasMaxLength(100);

        builder.Property(x => x.TotalBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDepreciation)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalAcquisitionCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalRevaluationGains)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalImpairmentLosses)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalRevenue)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalExpenses)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetIncome)
               .HasPrecision(18, 2);

        builder.Property(x => x.AuditStatus)
               .HasMaxLength(100);

        builder.Property(x => x.AuditFirmName)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}



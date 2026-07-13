using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M6_StatisticsReports.Configurations;

public class StatisticalReportSnapshotConfiguration : IEntityTypeConfiguration<StatisticalReportSnapshot>
{
    public void Configure(EntityTypeBuilder<StatisticalReportSnapshot> builder)
    {
        builder.ToTable("STATISTICAL_REPORT_SNAPSHOT");

        builder.Property(e => e.ReportCode)
            .HasColumnName("REPORT_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ReportNameAr)
            .HasColumnName("REPORT_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.ReportCategory)
            .HasColumnName("REPORT_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.SnapshotPayloadJson)
            .HasColumnName("SNAPSHOT_PAYLOAD_JSON");

        builder.Property(e => e.SnapshotDate)
            .HasColumnName("SNAPSHOT_DATE");

        builder.Property(e => e.IsVerifiedByOffice)
            .HasColumnName("IS_VERIFIED_BY_OFFICE");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AcademicLockPeriod)
            .WithMany()
            .HasForeignKey(e => e.AcademicLockPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.SchoolId, e.ReportCode });
    }
}

public class DashboardKpiConfigurationConfiguration : IEntityTypeConfiguration<DashboardKpiConfiguration>
{
    public void Configure(EntityTypeBuilder<DashboardKpiConfiguration> builder)
    {
        builder.ToTable("DASHBOARD_KPI_CONFIG");

        builder.Property(e => e.KpiCode)
            .HasColumnName("KPI_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.KpiNameAr)
            .HasColumnName("KPI_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.KpiNameEn)
            .HasColumnName("KPI_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.SourceModule)
            .HasColumnName("SOURCE_MODULE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.TargetValue)
            .HasColumnName("TARGET_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.ThresholdGreen)
            .HasColumnName("THRESHOLD_GREEN")
            .HasPrecision(19, 4);

        builder.Property(e => e.ThresholdYellow)
            .HasColumnName("THRESHOLD_YELLOW")
            .HasPrecision(19, 4);

        builder.Property(e => e.ThresholdRed)
            .HasColumnName("THRESHOLD_RED")
            .HasPrecision(19, 4);
    }
}

public class KpiMetricRecordConfiguration : IEntityTypeConfiguration<KpiMetricRecord>
{
    public void Configure(EntityTypeBuilder<KpiMetricRecord> builder)
    {
        builder.ToTable("KPI_METRIC_RECORD");

        builder.Property(e => e.ActualValue)
            .HasColumnName("ACTUAL_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.TargetValue)
            .HasColumnName("TARGET_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.PreviousValue)
            .HasColumnName("PREVIOUS_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.ChangePercentage)
            .HasColumnName("CHANGE_PERCENTAGE")
            .HasPrecision(18, 4);

        builder.HasOne(e => e.KpiConfig)
            .WithMany()
            .HasForeignKey(e => e.KpiConfigId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class TrendAnalysisResultConfiguration : IEntityTypeConfiguration<TrendAnalysisResult>
{
    public void Configure(EntityTypeBuilder<TrendAnalysisResult> builder)
    {
        builder.ToTable("TREND_ANALYSIS_RESULT");

        builder.Property(e => e.StudyPeriod)
            .HasColumnName("STUDY_PERIOD")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Slope)
            .HasColumnName("SLOPE")
            .HasPrecision(19, 4);

        builder.Property(e => e.CorrelationCoefficient)
            .HasColumnName("CORRELATION_COEFFICIENT")
            .HasPrecision(19, 4);

        builder.Property(e => e.ForecastedValueNext1Year)
            .HasColumnName("FORECASTED_VALUE_NEXT_1_YEAR")
            .HasPrecision(19, 4);

        builder.Property(e => e.ForecastedValueNext2Year)
            .HasColumnName("FORECASTED_VALUE_NEXT_2_YEAR")
            .HasPrecision(19, 4);

        builder.Property(e => e.ConfidenceLevel)
            .HasColumnName("CONFIDENCE_LEVEL")
            .HasPrecision(18, 4);

        builder.Property(e => e.LowerBound)
            .HasColumnName("LOWER_BOUND")
            .HasPrecision(19, 4);

        builder.Property(e => e.UpperBound)
            .HasColumnName("UPPER_BOUND")
            .HasPrecision(19, 4);
    }
}

public class SchoolStatisticsDraftConfiguration : IEntityTypeConfiguration<SchoolStatisticsDraft>
{
    public void Configure(EntityTypeBuilder<SchoolStatisticsDraft> builder)
    {
        builder.ToTable("SCHOOL_STATISTICS_DRAFT");

        builder.Property(e => e.DraftNumber)
            .HasColumnName("DRAFT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CompletenessPercentage)
            .HasColumnName("COMPLETENESS_PERCENTAGE")
            .HasPrecision(18, 2);

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SubmittedStatisticsConfiguration : IEntityTypeConfiguration<SubmittedStatistics>
{
    public void Configure(EntityTypeBuilder<SubmittedStatistics> builder)
    {
        builder.ToTable("SUBMITTED_STATISTICS");

        builder.Property(e => e.SubmissionNumber)
            .HasColumnName("SUBMISSION_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(e => e.StatisticsDraft)
            .WithMany()
            .HasForeignKey(e => e.StatisticsDraftId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StatisticsUpdateHistoryConfiguration : IEntityTypeConfiguration<StatisticsUpdateHistory>
{
    public void Configure(EntityTypeBuilder<StatisticsUpdateHistory> builder)
    {
        builder.ToTable("STATISTICS_UPDATE_HISTORY");

        builder.Property(e => e.ChangeType)
            .HasColumnName("CHANGE_TYPE")
            .HasMaxLength(100)
            .IsRequired();
    }
}

public class StatisticsArchiveConfiguration : IEntityTypeConfiguration<StatisticsArchive>
{
    public void Configure(EntityTypeBuilder<StatisticsArchive> builder)
    {
        builder.ToTable("STATISTICS_ARCHIVE");

        builder.Property(e => e.ArchivedYear)
            .HasColumnName("ARCHIVED_YEAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(e => e.SubmittedStatistics)
            .WithMany()
            .HasForeignKey(e => e.SubmittedStatisticsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SystemReportConfiguration : IEntityTypeConfiguration<SystemReport>
{
    public void Configure(EntityTypeBuilder<SystemReport> builder)
    {
        builder.ToTable("SYSTEM_REPORT");

        builder.Property(e => e.ReportType)
            .HasColumnName("REPORT_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ReportTitle)
            .HasColumnName("REPORT_TITLE")
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ReportApprovalConfiguration : IEntityTypeConfiguration<ReportApproval>
{
    public void Configure(EntityTypeBuilder<ReportApproval> builder)
    {
        builder.ToTable("REPORT_APPROVAL");

        builder.HasOne(e => e.SystemReport)
            .WithMany()
            .HasForeignKey(e => e.SystemReportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ComparativeReportConfiguration : IEntityTypeConfiguration<ComparativeReport>
{
    public void Configure(EntityTypeBuilder<ComparativeReport> builder)
    {
        builder.ToTable("COMPARATIVE_REPORT");

        builder.Property(e => e.ReportNumber)
            .HasColumnName("REPORT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ComparisonTitle)
            .HasColumnName("COMPARISON_TITLE")
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SchoolFinancialSummaryReportConfiguration : IEntityTypeConfiguration<SchoolFinancialSummaryReport>
{
    public void Configure(EntityTypeBuilder<SchoolFinancialSummaryReport> builder)
    {
        builder.ToTable("SCHOOL_FINANCIAL_SUMMARY_REPORT");

        builder.Property(e => e.FiscalYear)
            .HasColumnName("FISCAL_YEAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.TotalBookValue)
            .HasColumnName("TOTAL_BOOK_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalDepreciation)
            .HasColumnName("TOTAL_DEPRECIATION")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalAcquisitionCost)
            .HasColumnName("TOTAL_ACQUISITION_COST")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalRevaluationGains)
            .HasColumnName("TOTAL_REVALUATION_GAINS")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalImpairmentLosses)
            .HasColumnName("TOTAL_IMPAIRMENT_LOSSES")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalRevenue)
            .HasColumnName("TOTAL_REVENUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.TotalExpenses)
            .HasColumnName("TOTAL_EXPENSES")
            .HasPrecision(19, 4);

        builder.Property(e => e.NetIncome)
            .HasColumnName("NET_INCOME")
            .HasPrecision(19, 4);

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ExternalComplianceReportConfiguration : IEntityTypeConfiguration<ExternalComplianceReport>
{
    public void Configure(EntityTypeBuilder<ExternalComplianceReport> builder)
    {
        builder.ToTable("EXTERNAL_COMPLIANCE_REPORT");

        builder.Property(e => e.ReportNumber)
            .HasColumnName("REPORT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.TargetEntityName)
            .HasColumnName("TARGET_ENTITY_NAME")
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class GapAnalysisReportConfiguration : IEntityTypeConfiguration<GapAnalysisReport>
{
    public void Configure(EntityTypeBuilder<GapAnalysisReport> builder)
    {
        builder.ToTable("GAP_ANALYSIS_REPORT");

        builder.Property(e => e.AnalysisNumber)
            .HasColumnName("ANALYSIS_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.GapValue)
            .HasColumnName("GAP_VALUE")
            .HasPrecision(19, 4);

        builder.Property(e => e.GapPercentage)
            .HasColumnName("GAP_PERCENTAGE")
            .HasPrecision(18, 4);

        builder.Property(e => e.EstimatedCost)
            .HasColumnName("ESTIMATED_COST")
            .HasPrecision(19, 4);

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StatisticsReportsArchiveConfiguration : IEntityTypeConfiguration<StatisticsReportsArchive>
{
    public void Configure(EntityTypeBuilder<StatisticsReportsArchive> builder)
    {
        builder.ToTable("STATISTICS_REPORTS_ARCHIVE");

        builder.Property(e => e.SourceReportType)
            .HasColumnName("SOURCE_REPORT_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ExceptionalStatisticsReportConfiguration : IEntityTypeConfiguration<ExceptionalStatisticsReport>
{
    public void Configure(EntityTypeBuilder<ExceptionalStatisticsReport> builder)
    {
        builder.ToTable("EXCEPTIONAL_STATISTICS_REPORT");

        builder.Property(e => e.ReportNumber)
            .HasColumnName("REPORT_NUMBER")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.TotalDamageCost)
            .HasColumnName("TOTAL_DAMAGE_COST")
            .HasPrecision(19, 4);

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

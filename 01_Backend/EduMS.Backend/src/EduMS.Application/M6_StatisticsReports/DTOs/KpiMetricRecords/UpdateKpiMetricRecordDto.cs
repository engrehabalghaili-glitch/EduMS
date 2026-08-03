using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.KpiMetricRecords;

public class UpdateKpiMetricRecordDto
{
    public long Id { get; set; }
    public long KpiConfigId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int PeriodType { get; set; }
    public int PeriodValue { get; set; }
    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public decimal ActualValue { get; set; }
    public decimal? TargetValue { get; set; }
    public decimal? PreviousValue { get; set; }
    public decimal ChangePercentage { get; set; }
    public string? StatusColor { get; set; }
    public int CalculationMethod { get; set; }
    public DateTime CalculationDate { get; set; } = DateTime.UtcNow;
    public long? CalculatedByUserId { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? Notes { get; set; }
}

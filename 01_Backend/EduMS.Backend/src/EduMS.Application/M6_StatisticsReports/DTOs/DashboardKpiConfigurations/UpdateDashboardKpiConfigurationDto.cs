using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.DashboardKpiConfigurations;

public class UpdateDashboardKpiConfigurationDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string KpiCode { get; set; } = string.Empty;
    public string KpiNameAr { get; set; } = string.Empty;
    public string? KpiNameEn { get; set; }
    public string? KpiDescription { get; set; }
    public string SourceModule { get; set; } = string.Empty;
    public string? SourceTable { get; set; }
    public string? SourceField { get; set; }
    public int AggregationMethod { get; set; }
    public int ChartType { get; set; }
    public int RefreshIntervalMinutes { get; set; } = 60;
    public decimal? TargetValue { get; set; }
    public decimal? ThresholdGreen { get; set; }
    public decimal? ThresholdYellow { get; set; }
    public decimal? ThresholdRed { get; set; }
    public bool AlertEnabled { get; set; }
    public string? AlertRecipientsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; }
    public long? DashboardId { get; set; }
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;

public class CreateDirectorateStatisticalReportDto
{
    public long DirectorateId { get; set; }
    public string ReportCode { get; set; } = string.Empty;
    public string ReportTitleAr { get; set; } = string.Empty;
    public string? ReportTitleEn { get; set; }
    public int TargetCategory { get; set; }
    public int PeriodType { get; set; }
    public string TargetAcademicYear { get; set; } = string.Empty;
    public string StatisticalDataPayloadJson { get; set; } = string.Empty;
    public string? AnalyticalSummary { get; set; }
    public string? RecommendationsText { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? CompiledByEmployeeId { get; set; }
    public int VerificationStatus { get; set; } = 1;
}

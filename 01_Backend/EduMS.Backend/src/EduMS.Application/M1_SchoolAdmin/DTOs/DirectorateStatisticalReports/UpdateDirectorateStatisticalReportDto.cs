using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;

public class UpdateDirectorateStatisticalReportDto
{
    public long Id { get; set; }
    public string ReportCode { get; set; }
    public string ReportTitleAr { get; set; }
    public string? ReportTitleEn { get; set; }
    public int TargetCategory { get; set; }
    public int PeriodType { get; set; }
    public string TargetAcademicYear { get; set; }
    public string StatisticalDataPayloadJson { get; set; }
    public string? AnalyticalSummary { get; set; }
    public string? RecommendationsText { get; set; }
    public DateTime GenerationDate { get; set; }
    public long? CompiledByEmployeeId { get; set; }
}

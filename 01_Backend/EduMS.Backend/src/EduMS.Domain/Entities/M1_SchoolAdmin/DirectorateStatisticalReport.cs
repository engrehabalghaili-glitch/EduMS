using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class DirectorateStatisticalReport : BaseAuditableEntity
{
    public long DirectorateId { get; set; }
    public string ReportCode { get; set; } = string.Empty;
    public string ReportTitleAr { get; set; } = string.Empty;
    public string? ReportTitleEn { get; set; }
    public int TargetCategory { get; set; } // 1=StudentStatistics, 2=TeacherStaffing, 3=SchoolInfrastructure, 4=AcademicPerformance
    public int PeriodType { get; set; } // 1=Monthly, 2=Quarterly, 3=Annual, 4=TenYearPlan
    public string TargetAcademicYear { get; set; } = string.Empty;
    public string StatisticalDataPayloadJson { get; set; } = string.Empty;
    public string? AnalyticalSummary { get; set; }
    public string? RecommendationsText { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? CompiledByEmployeeId { get; set; }
    public int VerificationStatus { get; set; } = 1; // 1=Draft, 2=VerifiedByHead, 3=PublishedToMinistry

    // Navigation Property
    public virtual Directorate? Directorate { get; set; }
    public virtual Employee? CompiledByEmployee { get; set; }
}

using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// إعدادات مؤشرات الأداء على لوحة التحكم - extracted from ZIP ERD DashboardConfiguration (lines 7991-8019).
/// </summary>
public class DashboardKpiConfiguration : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string KpiCode { get; set; } = string.Empty;
    public string KpiNameAr { get; set; } = string.Empty;
    public string? KpiNameEn { get; set; }
    public string? KpiDescription { get; set; }
    public string SourceModule { get; set; } = string.Empty; // Students, Employees, Assets, Finance
    public string? SourceTable { get; set; }
    public string? SourceField { get; set; }
    public int AggregationMethod { get; set; } // 1=Sum, 2=Average, 3=Count, 4=Percentage, 5=Min, 6=Max
    public int ChartType { get; set; } // 1=Bar, 2=Line, 3=Pie, 4=Table, 5=Counter, 6=ProgressBar
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

/// <summary>
/// قيم مؤشرات الأداء المحسوبة دورياً - extracted from ZIP ERD KPI_Metrics (lines 8021-8048).
/// </summary>
public class KpiMetricRecord : BaseAuditableEntity
{
    public long KpiConfigId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int PeriodType { get; set; } // 1=Daily, 2=Weekly, 3=Monthly, 4=Quarterly, 5=SemiAnnual, 6=Annual
    public int PeriodValue { get; set; }
    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public decimal ActualValue { get; set; }
    public decimal? TargetValue { get; set; }
    public decimal? PreviousValue { get; set; }
    public decimal ChangePercentage { get; set; }
    public string? StatusColor { get; set; } // Green, Yellow, Red
    public int CalculationMethod { get; set; } // 1=Automatic, 2=Manual, 3=Imported
    public DateTime CalculationDate { get; set; } = DateTime.UtcNow;
    public long? CalculatedByUserId { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? Notes { get; set; }

    public virtual DashboardKpiConfiguration? KpiConfig { get; set; }
}

/// <summary>
/// نتائج تحليل الاتجاهات والتنبؤات - extracted from ZIP ERD TrendAnalysisResult (lines 8050-8080).
/// </summary>
public class TrendAnalysisResult : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string StudyPeriod { get; set; } = string.Empty;
    public string StartYear { get; set; } = string.Empty;
    public string EndYear { get; set; } = string.Empty;
    public string KpiCode { get; set; } = string.Empty;
    public string? HistoricalValuesJson { get; set; }
    public string? TrendDirection { get; set; } // Ascending, Descending, Stable, Cyclic
    public decimal? Slope { get; set; }
    public decimal? CorrelationCoefficient { get; set; }
    public decimal? ForecastedValueNext1Year { get; set; }
    public decimal? ForecastedValueNext2Year { get; set; }
    public decimal? ConfidenceLevel { get; set; }
    public decimal? LowerBound { get; set; }
    public decimal? UpperBound { get; set; }
    public string? ForecastingMethod { get; set; } // LinearRegression, MovingAverage
    public DateTime AnalysisDate { get; set; }
    public long? AnalyzedByUserId { get; set; }
    public int AnalysisStatus { get; set; } = 1; // 1=Draft, 2=Approved
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// مسودة الإحصائية المدرسية - extracted from ZIP ERD SchoolStatisticsDraft (lines 8082-8110).
/// </summary>
public class SchoolStatisticsDraft : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public int PeriodType { get; set; } // 1=Monthly, 2=Quarterly, 3=Semester, 4=Annual
    public int PeriodValue { get; set; }
    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public string DraftNumber { get; set; } = string.Empty;
    public string DraftVersion { get; set; } = "1.0";
    public string? StudentDataJson { get; set; }
    public string? StaffDataJson { get; set; }
    public string? FinancialSummaryJson { get; set; }
    public string? AssetSummaryJson { get; set; }
    public decimal CompletenessPercentage { get; set; }
    public int DraftStatus { get; set; } = 1; // 1=New, 2=InProgress, 3=Complete, 4=ReadyForSubmission, 5=UnderReview, 6=Submitted
    public bool IsLocked { get; set; }
    public DateTime? LockedAt { get; set; }
    public long? LockedByUserId { get; set; }
    public DateTime? LastSavedAt { get; set; }
    public long? SavedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// الإحصائية المرفوعة رسمياً - extracted from ZIP ERD SubmittedStatistics (lines 8112-8144).
/// </summary>
public class SubmittedStatistics : BaseAuditableEntity
{
    public long StatisticsDraftId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string SubmissionNumber { get; set; } = string.Empty;
    public DateTime SubmissionTimestamp { get; set; } = DateTime.UtcNow;
    public int SubmissionMethod { get; set; } // 1=Portal, 2=OfficialEmail, 3=Manual
    public long SubmittedByUserId { get; set; }
    public string? DirectorSignatureHash { get; set; }
    public DateTime? DirectorSignatureDate { get; set; }
    public string? StudentDataSnapshotJson { get; set; }
    public string? StaffDataSnapshotJson { get; set; }
    public string? FinancialSummarySnapshotJson { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Pending, 2=UnderReview, 3=Accepted, 4=RejectedForRevision, 5=FinallyApproved
    public string? ReviewerNotes { get; set; }
    public DateTime? ReviewDate { get; set; }
    public long? ReviewedByUserId { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool IsFinal { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolStatisticsDraft? StatisticsDraft { get; set; }
}

/// <summary>
/// سجل تغييرات الإحصائية - extracted from ZIP ERD StatisticsUpdateHistory (lines 8146-8168).
/// </summary>
public class StatisticsUpdateHistory : BaseAuditableEntity
{
    public long? StatisticsDraftId { get; set; }
    public long? SubmittedStatisticsId { get; set; }
    public long SchoolId { get; set; }
    public string ChangeType { get; set; } = string.Empty;
    public string ChangeCategory { get; set; } = string.Empty; // Students, Staff, Finance, Assets
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime ChangeDate { get; set; }
    public string? UpdateReason { get; set; }
    public string? SupportingDocumentUrl { get; set; }
    public long? ChangedByUserId { get; set; }
    public bool IsApproved { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// أرشيف الإحصائيات التاريخية غير القابل للتعديل - extracted from ZIP ERD StatisticsArchive (lines 8170-8193).
/// </summary>
public class StatisticsArchive : BaseAuditableEntity
{
    public long SubmittedStatisticsId { get; set; }
    public long SchoolId { get; set; }
    public string ArchivedYear { get; set; } = string.Empty;
    public int PeriodType { get; set; }
    public DateTime ArchivedAt { get; set; } = DateTime.UtcNow;
    public long ArchivedByUserId { get; set; }
    public string? FinalDataSnapshotJson { get; set; }
    public string? StudentSnapshotJson { get; set; }
    public string? StaffSnapshotJson { get; set; }
    public int RetentionPeriodYears { get; set; } = 10;
    public DateTime? RetentionEndDate { get; set; }
    public bool IsReadOnly { get; set; } = true;
    public string? Notes { get; set; }

    public virtual SubmittedStatistics? SubmittedStatistics { get; set; }
}

/// <summary>
/// التقارير النظامية الدورية والحسب الطلب - extracted from ZIP ERD SystemReports (lines 8195-8222).
/// </summary>
public class SystemReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public string? ReportSubType { get; set; }
    public string ReportTitle { get; set; } = string.Empty;
    public int ReportFrequency { get; set; } // 1=Daily, 2=Weekly, 3=Monthly, 4=Quarterly, 5=Annual, 6=OnDemand
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public int GenerationMethod { get; set; } // 1=Automatic, 2=Manual
    public long? GeneratedByUserId { get; set; }
    public string? FileFormat { get; set; } // PDF, Excel, CSV
    public string? FilePath { get; set; }
    public long FileSizeBytes { get; set; }
    public int ReportStatus { get; set; } = 1; // 1=Draft, 2=Published, 3=Archived
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public long? PublishedByUserId { get; set; }
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// اعتمادات التقارير - extracted from ZIP ERD ReportApprovals (lines 8224-8248).
/// </summary>
public class ReportApproval : BaseAuditableEntity
{
    public long SystemReportId { get; set; }
    public long SchoolId { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public long SubmittedByUserId { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Draft, 2=AwaitingReview, 3=UnderReview, 4=Approved, 5=Rejected, 6=Cancelled
    public long? ReviewerId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? Comments { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? DigitalSignatureHash { get; set; }
    public string? CertificateNumber { get; set; }
    public string? CertificatePath { get; set; }
    public bool IsFinal { get; set; }
    public string? Notes { get; set; }

    public virtual SystemReport? SystemReport { get; set; }
}

/// <summary>
/// التقارير المقارنة بين الفترات - extracted from ZIP ERD ComparativeReport (lines 8250-8280).
/// </summary>
public class ComparativeReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public string ComparisonTitle { get; set; } = string.Empty;
    public string FirstPeriodLabel { get; set; } = string.Empty;
    public string FirstPeriodStart { get; set; } = string.Empty;
    public string FirstPeriodEnd { get; set; } = string.Empty;
    public string SecondPeriodLabel { get; set; } = string.Empty;
    public string SecondPeriodStart { get; set; } = string.Empty;
    public string SecondPeriodEnd { get; set; } = string.Empty;
    public string ComparisonType { get; set; } = string.Empty; // Time, InterSchool, InterCategory
    public string? KpiComparedJson { get; set; }
    public string? ComparisonDataJson { get; set; }
    public string? AutoInsights { get; set; }
    public string? Summary { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FileFormat { get; set; }
    public string? FilePath { get; set; }
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }
    public int ReportStatus { get; set; } = 1; // 1=Draft, 2=Published, 3=Archived
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// الملخص المالي للمدرسة بالإحصائية - extracted from ZIP ERD FinancialSummaryReports (lines 8282-8312) in M6.
/// Note: M4 has AssetFinancialAuditArchive for asset-only reports. This M6 entity covers cross-module consolidated view.
/// </summary>
public class SchoolFinancialSummaryReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public int ReportType { get; set; } // 1=Annual, 2=Quarterly, 3=OnDemand
    public decimal TotalBookValue { get; set; }
    public decimal TotalDepreciation { get; set; }
    public int TotalAssetsCount { get; set; }
    public decimal TotalAcquisitionCost { get; set; }
    public decimal TotalRevaluationGains { get; set; }
    public decimal TotalImpairmentLosses { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal NetIncome { get; set; }
    public string? AuditStatus { get; set; }
    public string? AuditFirmName { get; set; }
    public DateTime? AuditDate { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Draft, 2=Approved
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? FilePath { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// تقارير الامتثال والرفع لجهات خارجية - extracted from ZIP ERD ExternalComplianceReports (lines 8314-8348).
/// </summary>
public class ExternalComplianceReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public string TargetEntityName { get; set; } = string.Empty; // Ministry, EducationOffice, QualityBoard
    public int EntityType { get; set; } // 1=Government, 2=Private, 3=International
    public string? StandardType { get; set; }
    public int ReportType { get; set; } // 1=AnnualCompliance, 2=Quality, 3=Licensing, 4=OfficialStats
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FilePath { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public int SubmissionMethod { get; set; } // 1=API, 2=OfficialEmail, 3=Portal, 4=Manual
    public string? ReceiptReference { get; set; }
    public DateTime? ReceiptDate { get; set; }
    public int SubmissionStatus { get; set; } = 1; // 1=InPreparation, 2=Sent, 3=Received, 4=Accepted, 5=Rejected, 6=Failed
    public string? RejectionReason { get; set; }
    public bool IsFinal { get; set; }
    public DateTime? FinalApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// تحليلات الفجوة الاحتياجية - extracted from ZIP ERD GapAnalysisReports (lines 8350-8378).
/// </summary>
public class GapAnalysisReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string AnalysisNumber { get; set; } = string.Empty;
    public string AnalysisType { get; set; } = string.Empty; // Students-Teachers, Students-Classrooms, Assets-Curriculum
    public long? AssetCategoryId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? DepartmentId { get; set; }
    public int RequiredQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal GapValue { get; set; }
    public decimal GapPercentage { get; set; }
    public string? GapType { get; set; } // Deficit, Surplus, Match
    public string? Recommendation { get; set; }
    public int Priority { get; set; } // 1=High, 2=Medium, 3=Low
    public decimal EstimatedCost { get; set; }
    public DateTime AnalysisDate { get; set; }
    public long? AnalyzedByUserId { get; set; }
    public string? FilePath { get; set; }
    public int AnalysisStatus { get; set; } = 1; // 1=Draft, 2=Approved, 3=Implemented
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// أرشيف التقارير بمدد احتفاظ قانونية - extracted from ZIP ERD ReportsArchive (lines 8380-8402).
/// </summary>
public class StatisticsReportsArchive : BaseAuditableEntity
{
    public string SourceReportType { get; set; } = string.Empty; // SystemReport, ComparativeReport, FinancialSummaryReport
    public long SourceReportId { get; set; }
    public long SchoolId { get; set; }
    public DateTime ArchivedAt { get; set; } = DateTime.UtcNow;
    public long ArchivedByUserId { get; set; }
    public int RetentionPeriodYears { get; set; } = 7;
    public DateTime? RetentionEndDate { get; set; }
    public string? FilePath { get; set; }
    public long FileSizeBytes { get; set; }
    public bool IsReadOnly { get; set; } = true;
    public DateTime? DisposalDate { get; set; }
    public int DisposalStatus { get; set; } = 1; // 1=Pending, 2=Disposed
    public string? DisposalMethod { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// الإحصائيات الاستثنائية - extracted from ZIP ERD ExceptionalStatistics (lines 8404-8431).
/// </summary>
public class ExceptionalStatisticsReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public int TotalIncidents { get; set; }
    public int TotalClosureDays { get; set; }
    public decimal TotalDamageCost { get; set; }
    public int TotalAwardsCount { get; set; }
    public int TotalParticipationsCount { get; set; }
    public int TotalDeficitCount { get; set; }
    public int TotalSurplusCount { get; set; }
    public string? EmergencySummaryJson { get; set; }
    public string? ClosureSummaryJson { get; set; }
    public string? AwardSummaryJson { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FilePath { get; set; }
    public int ReportStatus { get; set; } = 1; // 1=Draft, 2=Approved
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// لقطة إحصائيات المديرية الموحدة - تجميع بيانات جميع المدارس التابعة لمكتب التربية.
/// هذا الكيان يُمثّل المستوى الثاني (مستوى المكتب) في هرمية التقارير.
/// يُغذَّى من Oracle Materialized View: directorate_school_stats_mv.
/// </summary>
public class DirectorateStatisticsSnapshot : BaseAuditableEntity
{
    /// <summary>معرف المديرية/مكتب التربية - FK إلى Directorate</summary>
    public long DirectorateId { get; set; }

    /// <summary>معرف السنة الدراسية - FK إلى SchoolAcademicYear</summary>
    public long AcademicYearId { get; set; }

    /// <summary>نوع الفترة: 1=شهري، 2=ربع سنوي، 3=نصف سنوي، 4=سنوي</summary>
    public int PeriodType { get; set; } = 4;

    /// <summary>قيمة الفترة (مثل: 1 للشهر الأول، 2 للربع الثاني)</summary>
    public int PeriodValue { get; set; }

    /// <summary>تاريخ بداية فترة الإحصاء</summary>
    public DateTime PeriodStartDate { get; set; }

    /// <summary>تاريخ نهاية فترة الإحصاء</summary>
    public DateTime PeriodEndDate { get; set; }

    // === مؤشرات التجميع الرئيسية ===
    /// <summary>إجمالي المدارس النشطة في المديرية</summary>
    public int TotalSchools { get; set; }

    /// <summary>إجمالي الطلاب في جميع مدارس المديرية</summary>
    public int TotalStudents { get; set; }

    /// <summary>إجمالي الموظفين (معلمين + إداريين) في المديرية</summary>
    public int TotalEmployees { get; set; }

    /// <summary>إجمالي المعلمين فقط</summary>
    public int TotalTeachers { get; set; }

    /// <summary>معدل التسرب الدراسي على مستوى المديرية (نسبة مئوية)</summary>
    public decimal DropoutRate { get; set; }

    /// <summary>متوسط نسبة النجاح على مستوى المديرية (نسبة مئوية)</summary>
    public decimal AvgPassRate { get; set; }

    /// <summary>متوسط نسبة الحضور على مستوى المديرية (نسبة مئوية)</summary>
    public decimal AvgAttendanceRate { get; set; }

    /// <summary>عدد المدارس ذات كثافة طلابية عالية (مكتظة)</summary>
    public int OvercrowdedSchoolsCount { get; set; }

    /// <summary>عدد المدارس ذات عجز في المعلمين</summary>
    public int StaffShortageSchoolsCount { get; set; }

    // === البيانات التفصيلية (JSON) ===
    /// <summary>لقطة تفصيلية بأداء كل مدرسة على حدة (JSON array)</summary>
    public string? PerSchoolBreakdownJson { get; set; }

    /// <summary>ملخص مالي موحد للمديرية (JSON)</summary>
    public string? FinancialSummaryJson { get; set; }

    /// <summary>تحليل عجز/فائض الكادر حسب التخصص (JSON)</summary>
    public string? StaffShortageAnalysisJson { get; set; }

    // === حالة اللقطة وإدارة دورة حياتها ===
    /// <summary>حالة اللقطة: 1=مسودة، 2=معتمدة، 3=مرفوعة للوزارة، 4=مؤرشفة</summary>
    public int SnapshotStatus { get; set; } = 1;

    /// <summary>هل تم اعتماد هذه اللقطة رسمياً؟</summary>
    public bool IsOfficial { get; set; }

    /// <summary>معرف مدير المكتب الذي اعتمد اللقطة</summary>
    public long? ApprovedByUserId { get; set; }

    /// <summary>تاريخ الاعتماد الرسمي</summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>هل هذه اللقطة ناتجة عن تحديث تلقائي من Materialized View؟</summary>
    public bool IsAutoGenerated { get; set; } = true;

    /// <summary>آخر وقت تم فيه تحديث قيم MV في Oracle</summary>
    public DateTime? MaterializedViewLastRefresh { get; set; }

    public string? Notes { get; set; }

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
}

/// <summary>
/// سجل تقارير مكتب التربية المقدمة للجهات العليا (الوزارة أو المستوى الإداري الأعلى).
/// هذا الكيان يُمثّل العملية التنفيذية لرفع التقارير من المكتب إلى الجهات العليا.
/// </summary>
public class OfficeReportSubmission : BaseAuditableEntity
{
    /// <summary>معرف المديرية/مكتب التربية - FK إلى Directorate</summary>
    public long DirectorateId { get; set; }

    /// <summary>معرف لقطة إحصائية المديرية المرفقة - FK إلى DirectorateStatisticsSnapshot (nullable)</summary>
    public long? DirectorateSnapshotId { get; set; }

    /// <summary>نوع التقرير:
    /// 1=إحصائية دورية، 2=تقرير أداء، 3=تقرير امتثال، 4=إحصائية وطنية، 5=تقرير عجز/فائض</summary>
    public int ReportType { get; set; }

    /// <summary>مسمى التقرير</summary>
    public string ReportTitle { get; set; } = string.Empty;

    /// <summary>وصف مختصر للفترة (مثل: "الفصل الأول 2025-2026")</summary>
    public string PeriodLabel { get; set; } = string.Empty;

    /// <summary>تاريخ بداية الفترة التي يغطيها التقرير</summary>
    public DateTime PeriodStart { get; set; }

    /// <summary>تاريخ نهاية الفترة التي يغطيها التقرير</summary>
    public DateTime PeriodEnd { get; set; }

    /// <summary>الجهة المستلمة: 1=وزارة التربية، 2=مستوى إداري أعلى، 3=جهة اعتماد، 4=جهة خارجية</summary>
    public int RecipientType { get; set; } = 1;

    /// <summary>اسم الجهة المستلمة</summary>
    public string? RecipientEntityName { get; set; }

    // === بيانات الملف والرفع ===
    /// <summary>مسار ملف التقرير (PDF أو Excel)</summary>
    public string? FilePath { get; set; }

    /// <summary>صيغة الملف: PDF, Excel, CSV</summary>
    public string? FileFormat { get; set; }

    /// <summary>حجم الملف بالبايت</summary>
    public long FileSizeBytes { get; set; }

    // === حالة الرفع والاعتماد ===
    /// <summary>حالة التقرير: 1=قيد الإعداد، 2=جاهز، 3=مُرسَل، 4=مُستلَم، 5=مقبول، 6=مرفوض</summary>
    public int SubmissionStatus { get; set; } = 1;

    /// <summary>طريقة الرفع: 1=بوابة إلكترونية، 2=بريد رسمي، 3=يدوي</summary>
    public int SubmissionMethod { get; set; } = 1;

    /// <summary>وقت الرفع الفعلي</summary>
    public DateTime? SubmissionTimestamp { get; set; }

    /// <summary>معرف مدير المكتب الذي رفع التقرير</summary>
    public long? SubmittedByUserId { get; set; }

    /// <summary>التوقيع الإلكتروني لمدير المكتب (تجزئة)</summary>
    public string? DirectorSignatureHash { get; set; }

    /// <summary>رقم إيصال الاستلام من الجهة العليا</summary>
    public string? ReceiptReference { get; set; }

    /// <summary>تاريخ الاستلام من الجهة العليا</summary>
    public DateTime? ReceiptDate { get; set; }

    /// <summary>سبب الرفض (إن وجد)</summary>
    public string? RejectionReason { get; set; }

    /// <summary>ملاحظات المراجع من الجهة العليا</summary>
    public string? ReviewerNotes { get; set; }

    /// <summary>هل هذا الرفع نهائي ومعتمد؟</summary>
    public bool IsFinal { get; set; }

    public string? Notes { get; set; }

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
    public virtual DirectorateStatisticsSnapshot? DirectorateSnapshot { get; set; }
}

using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// خطط الجرد الدوري - extracted from ZIP ERD InventoryPlans (lines 7543-7565).
/// </summary>
public class InventoryPlan : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PlanNumber { get; set; } = string.Empty;
    public string PlanNameAr { get; set; } = string.Empty;
    public int InventoryType { get; set; } // 1=Periodic, 2=Surprise, 3=AtClearance, 4=Partial
    public int ScopeType { get; set; } // 1=WholeSchool, 2=Department, 3=Category, 4=Location
    public long? ScopeValueId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? TargetEndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public long? TeamLeaderEmployeeId { get; set; }
    public string? AssignedTeamMembersJson { get; set; }
    public string? Instructions { get; set; }
    public int PlanStatus { get; set; } = 1; // 1=Draft, 2=Active, 3=Completed, 4=Cancelled, 5=UnderReview
    public decimal CompletionPercentage { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// نتائج الجرد الميداني المسحوب بـ QR/Barcode - extracted from ZIP ERD FieldInventoryLog (lines 7567-7589).
/// </summary>
public class FieldInventoryLog : BaseAuditableEntity
{
    public long InventoryPlanId { get; set; }
    public long SchoolId { get; set; }
    public long ScannerUserId { get; set; }
    public DateTime ScanTimestamp { get; set; }
    public string ScannedCode { get; set; } = string.Empty;
    public long? AssetId { get; set; }
    public string? PhysicalLocationText { get; set; }
    public int ActualCondition { get; set; } // 1=Good, 2=NeedsMaintenance, 3=Damaged, 4=NonFunctional
    public string? ConditionNotes { get; set; }
    public bool IsFound { get; set; } = true;
    public string? NotFoundNotes { get; set; }
    public string? AssetPhotoUrl { get; set; }
    public string? GpsLocation { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? Notes { get; set; }

    public virtual InventoryPlan? InventoryPlan { get; set; }
}

/// <summary>
/// مطابقة فروقات الجرد والمعالجة - extracted from ZIP ERD InventoryReconciliation (lines 7591-7616).
/// </summary>
public class InventoryReconciliation : BaseAuditableEntity
{
    public long InventoryPlanId { get; set; }
    public long SchoolId { get; set; }
    public long AssetId { get; set; }
    public int DiscrepancyType { get; set; } // 1=Match, 2=Missing, 3=Surplus, 4=Damaged, 5=LocationMismatch, 6=ConditionMismatch
    public long? SystemLocationId { get; set; }
    public string? ActualLocationText { get; set; }
    public int SystemCondition { get; set; }
    public int ActualCondition { get; set; }
    public string? ReasonForDiscrepancy { get; set; }
    public string? InvestigationNotes { get; set; }
    public string? CorrectiveAction { get; set; }
    public bool IsResolved { get; set; }
    public DateTime? ResolutionDate { get; set; }
    public long? ResolvedByUserId { get; set; }
    public string? ResolutionNotes { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int ReconciliationStatus { get; set; } = 1; // 1=Open, 2=UnderInvestigation, 3=Resolved, 4=Approved
    public string? Notes { get; set; }

    public virtual InventoryPlan? InventoryPlan { get; set; }
}

/// <summary>
/// جلسات التدقيق والامتثال - extracted from ZIP ERD ComplianceAudit (lines 7618-7645).
/// </summary>
public class AssetComplianceAudit : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string AuditNumber { get; set; } = string.Empty;
    public DateTime AuditDate { get; set; }
    public int AuditType { get; set; } // 1=Internal, 2=External, 3=Surprise, 4=Periodic
    public string? StandardType { get; set; } // ISO55000, MinistryRegulation, InternalPolicy
    public long AuditedByUserId { get; set; }
    public string? AuditScope { get; set; }
    public decimal ComplianceScore { get; set; }
    public string? ViolationsFoundJson { get; set; }
    public string? CorrectiveActionsRequired { get; set; }
    public string? CorrectiveActionsDeadline { get; set; }
    public int CorrectiveActionsStatus { get; set; } // 1=InProgress, 2=Completed, 3=Overdue
    public DateTime? FollowUpAuditDate { get; set; }
    public string? AuditReportUrl { get; set; }
    public int AuditStatus { get; set; } = 1; // 1=Planned, 2=InProgress, 3=Completed, 4=Cancelled
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// اعتماد نتائج الجرد أو التدقيق الرسمي - extracted from ZIP ERD FinalApprovalAudit (lines 7647-7666).
/// </summary>
public class AssetAuditFinalApproval : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? InventoryPlanId { get; set; }
    public long? ComplianceAuditId { get; set; }
    public int ApprovalType { get; set; } // 1=AnnualInventory, 2=InternalAudit, 3=ExternalAudit, 4=AssetWriteOff
    public DateTime ApprovalDate { get; set; }
    public long ApprovedByUserId { get; set; }
    public string? ApprovalDocumentUrl { get; set; }
    public string? SummaryOfChanges { get; set; }
    public bool SystemStatusUpdated { get; set; }
    public DateTime? StatusUpdateDate { get; set; }
    public long? StatusUpdatedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// تخصيص المرافق للأقسام - extracted from ZIP ERD FacilityDepartmentAssignment (lines 7668-7689).
/// </summary>
public class FacilityDepartmentAssignment : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public int FacilityType { get; set; } // 1=Classroom, 2=Lab, 3=Library, 4=GymHall, 5=Storage, 6=Office
    public long FacilityId { get; set; }
    public long? DepartmentId { get; set; }
    public long? ResponsibleEmployeeId { get; set; }
    public int AssignmentType { get; set; } // 1=Full, 2=Partial, 3=Temporary, 4=Permanent
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsShared { get; set; }
    public string? SharedWithDepartmentsJson { get; set; }
    public string? SharingScheduleJson { get; set; }
    public int Priority { get; set; } = 1;
    public int AssignmentStatus { get; set; } = 1; // 1=Active, 2=Expired, 3=Cancelled
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// تتبع استهلاك المواد التعليمية - extracted from ZIP ERD EducationalConsumablesTracking (lines 7691-7715).
/// </summary>
public class EducationalConsumableTracking : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ConsumableName { get; set; } = string.Empty;
    public string? ConsumableCode { get; set; }
    public string? Category { get; set; } // Ink, Paper, Chemicals, ArtSupplies, LabSupplies
    public int QuantityConsumed { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public DateTime ConsumptionDate { get; set; }
    public long? ConsumedByUserId { get; set; }
    public long? DepartmentId { get; set; }
    public long? SubjectId { get; set; }
    public string? Purpose { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalCost { get; set; }
    public string? BudgetLineCode { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// مقارنة جدوى الإصلاح مقابل الاستبدال - extracted from ZIP ERD FeasibilityComparison (lines 7320-7342).
/// </summary>
public class AssetFeasibilityComparison : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public DateTime ComparisonDate { get; set; }
    public decimal RepairEstimate { get; set; }
    public string? RepairEstimateBreakdownJson { get; set; }
    public decimal ReplacementCost { get; set; }
    public string? ReplacementCostBreakdownJson { get; set; }
    public string? TcoAnalysisJson { get; set; }
    public int Recommendation { get; set; } // 1=Repair, 2=Replace, 3=Decommission, 4=Defer
    public string? RecommendationReason { get; set; }
    public int DecisionStatus { get; set; } = 1; // 1=AwaitingDecision, 2=RepairApproved, 3=ReplacementApproved, 4=Cancelled
    public DateTime? DecisionDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// المواصفات الفنية القياسية للأصول - extracted from ZIP ERD TechnicalSpecifications (lines 6824-6851).
/// </summary>
public class AssetTechnicalSpecification : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string SpecCode { get; set; } = string.Empty;
    public string SpecNameAr { get; set; } = string.Empty;
    public string? SpecNameEn { get; set; }
    public long? AssetCategoryId { get; set; }
    public string? AssetTypeDescription { get; set; }
    public string? TechnicalDetailsJson { get; set; }
    public string? RequiredCertifications { get; set; }
    public string? AcceptanceCriteria { get; set; }
    public string? QualityStandards { get; set; }
    public string? WarrantyRequirements { get; set; }
    public string? SafetyRequirements { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string SpecVersion { get; set; } = "V1.0";
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// دراسات الجدوى ومخاطر المشتريات - extracted from ZIP ERD FeasibilityRiskAnalysis (lines 6853-6882).
/// </summary>
public class AssetFeasibilityRiskAnalysis : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? RequirementRequestId { get; set; }
    public string AnalysisNumber { get; set; } = string.Empty;
    public DateTime AnalysisDate { get; set; }
    public long? AnalystEmployeeId { get; set; }
    public string? OperationalRisks { get; set; }
    public string? FinancialRisks { get; set; }
    public int RiskLevel { get; set; } // 1=Low, 2=Medium, 3=High
    public string? RiskMitigationPlan { get; set; }
    public decimal UsefulLifeEstimateYears { get; set; }
    public decimal RoiEstimatePercent { get; set; }
    public decimal NpvEstimate { get; set; }
    public string? AlternativeSolutions { get; set; }
    public int FinalRecommendation { get; set; } // 1=Purchase, 2=Reject, 3=Defer, 4=Alternative
    public string? RecommendationReason { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int AnalysisStatus { get; set; } = 1; // 1=Draft, 2=Approved
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// ملخص مالي أرشيفي للأصول - extracted from ZIP ERD FinancialAuditArchive (lines 7344-7361) and FinancialSummaryReports (lines 7363-7389).
/// These are read-only archive snapshots; classified as physical entities for immutability enforcement.
/// </summary>
public class AssetFinancialAuditArchive : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public int ReportType { get; set; } // 1=Depreciation, 2=BookValue, 3=Revaluation, 4=AnnualSummary
    public string FiscalYear { get; set; } = string.Empty;
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; }
    public DateTime ArchivedDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAssetsValue { get; set; }
    public decimal TotalDepreciationValue { get; set; }
    public string? ReportFileUrl { get; set; }
    public bool IsReadOnly { get; set; } = true;  // Immutable archive; never edited after creation
    public string? AuditStatus { get; set; }
    public string? AuditFirmName { get; set; }
    public DateTime? AuditDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

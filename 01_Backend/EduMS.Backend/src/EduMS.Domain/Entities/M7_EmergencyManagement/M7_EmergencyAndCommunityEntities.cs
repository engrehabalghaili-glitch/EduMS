using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الاستضافة الطارئة - extracted from ZIP ERD EmergencyHosting (lines 8955-8986).
/// </summary>
public class EmergencyHosting : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string HostingNumber { get; set; } = string.Empty;
    public string HostingType { get; set; } = string.Empty; // Displaced, ExternalStudents, HealthPurpose, EmergencyCommandCenter
    public DateTime HostingDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ExpectedEndDate { get; set; }
    public int ActualCount { get; set; }
    public int MaxCapacity { get; set; }
    public decimal UtilizationPercentage { get; set; }
    public string? Reason { get; set; }
    public string? SourceLocation { get; set; }
    public string? SupportOrganization { get; set; }
    public string? SupportOrgContact { get; set; }
    public string? FacilitiesUsedJson { get; set; }
    public string? ResourcesProvidedJson { get; set; }
    public string? ResourcesReceivedJson { get; set; }
    public string? ExpensesJson { get; set; }
    public decimal TotalExpenses { get; set; }
    public int HostingStatus { get; set; } = 1; // 1=Active, 2=Ended, 3=InPreparation
    public string? ClosureNotes { get; set; }
    public string? LessonsLearned { get; set; }
    public long? ReportedByUserId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual SystemUser? ReportedByUser { get; set; }
}

/// <summary>
/// حوادث الطوارئ - extracted from ZIP ERD EmergencyIncidents (lines 8988-9026).
/// </summary>
public class EmergencyIncident : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string IncidentNumber { get; set; } = string.Empty;
    public string IncidentType { get; set; } = string.Empty; // Earthquake, Fire, Epidemic, SecurityDisturbance, Flood, Storm
    public DateTime IncidentDate { get; set; }
    public DateTime? IncidentTime { get; set; }
    public int Severity { get; set; } // 1=Low, 2=Medium, 3=High, 4=Critical
    public string? Description { get; set; }
    public string? LocationText { get; set; }
    public long? ReportedByUserId { get; set; }
    public DateTime? ReportedAt { get; set; }
    public bool IsPlanActive { get; set; }
    public long? EmergencyPlanId { get; set; }
    public int AffectedCount { get; set; }
    public int StudentsAffected { get; set; }
    public int EmployeesAffected { get; set; }
    public int InjuriesCount { get; set; }
    public int SevereInjuriesCount { get; set; }
    public int FatalitiesCount { get; set; }
    public decimal PropertyDamage { get; set; }
    public string? PropertyDamageDescription { get; set; }
    public string? EmergencyResponseActions { get; set; }
    public string? ExternalAgenciesJson { get; set; }
    public DateTime? ExternalResponseTime { get; set; }
    public int IncidentStatus { get; set; } = 1; // 1=Open, 2=InProgress, 3=Closed, 4=UnderInvestigation
    public DateTime? ClosureDate { get; set; }
    public string? ClosureNotes { get; set; }
    public string? InvestigationReportUrl { get; set; }
    public string? LessonsLearned { get; set; }
    public string? Recommendations { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual SystemUser? ReportedByUser { get; set; }
    public virtual EmergencyPlan? EmergencyPlan { get; set; }
}

/// <summary>
/// الإغلاق الطارئ للمدرسة - extracted from ZIP ERD EmergencyClosures (lines 9028-9056).
/// </summary>
public class EmergencyClosure : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ClosureNumber { get; set; } = string.Empty;
    public string ClosureReason { get; set; } = string.Empty; // WeatherConditions, Pandemic, SecurityThreat, TechnicalFailure, GovernmentOrder
    public string? DecisionAuthority { get; set; }
    public string? AuthorityDecisionNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public int TotalClosureDays { get; set; }
    public int SchoolDaysAffected { get; set; }
    public bool AlternativeEducationActivated { get; set; }
    public string? AlternativeEducationType { get; set; } // SynchronousOnline, AsynchronousOnline, CompensatoryLessons
    public string? AltEducationPlatform { get; set; }
    public string? AltEducationDetails { get; set; }
    public bool WasCompensated { get; set; }
    public long? CompensationRemediationPlanId { get; set; }
    public bool ParentNotificationSent { get; set; }
    public DateTime? ParentNotificationDate { get; set; }
    public string? ParentNotificationMethod { get; set; }
    public int ClosureStatus { get; set; } = 1; // 1=Planned, 2=Active, 3=Ended
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// خدمات النقل المدرسي - extracted from ZIP ERD TransportationServices (lines 9058-9093).
/// </summary>
public class TransportationService : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string RouteName { get; set; } = string.Empty;
    public string? RouteDescription { get; set; }
    public long? BusAssetId { get; set; }
    public string? BusPlateNumber { get; set; }
    public int? BusCapacity { get; set; }
    public string? BusModel { get; set; }
    public string? BusYear { get; set; }
    public long? DriverEmployeeId { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public string? DriverPhone { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public string? SupervisorPhone { get; set; }
    public long? ShiftId { get; set; }
    public int TripType { get; set; } // 1=Morning, 2=Afternoon, 3=AllDay
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? EstimatedDurationMinutes { get; set; }
    public string? StopsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public int ServiceStatus { get; set; } = 1; // 1=Active, 2=Suspended, 3=Full
    public string? OperatorCompany { get; set; }
    public long? ContractId { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual SchoolAsset? BusAsset { get; set; }
    public virtual Employee? DriverEmployee { get; set; }
    public virtual Employee? SupervisorEmployee { get; set; }
}

/// <summary>
/// عمليات الدمج المدرسي - extracted from ZIP ERD SchoolMergers (lines 9095-9117).
/// </summary>
public class SchoolMerger : BaseAuditableEntity
{
    public string MergerNumber { get; set; } = string.Empty;
    public DateTime MergerDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string SourceSchoolIdsJson { get; set; } = string.Empty;
    public long TargetSchoolId { get; set; }
    public string? MergerReason { get; set; }
    public string? DecisionAuthority { get; set; }
    public string? DecisionDocumentPath { get; set; }
    public int StudentsTransferStatus { get; set; } // 1=InProgress, 2=Complete
    public int EmployeesTransferStatus { get; set; }
    public int AssetsTransferStatus { get; set; }
    public int MergerStatus { get; set; } = 1; // 1=Planned, 2=InProgress, 3=Complete, 4=Cancelled
    public DateTime? CompletionDate { get; set; }
    public string? CompletionNotes { get; set; }
    public string? Notes { get; set; }

    public virtual School? TargetSchool { get; set; }
}

/// <summary>
/// الجوائز والتميز المدرسي - extracted from ZIP ERD SchoolAwards (lines 9119-9145).
/// </summary>
public class SchoolAward : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string AwardNumber { get; set; } = string.Empty;
    public string AwardName { get; set; } = string.Empty;
    public string? AwardCategory { get; set; } // Educational, Sport, Cultural, Environmental, CommunityService
    public int AwardLevel { get; set; } // 1=Local, 2=National, 3=Regional, 4=International
    public string? IssuingBody { get; set; }
    public string? IssuingBodyType { get; set; } // Government, Private, International
    public DateTime AwardDate { get; set; }
    public string? AwardPlace { get; set; }
    public string? Ranking { get; set; }
    public string? ParticipantsJson { get; set; }
    public int StudentParticipantsCount { get; set; }
    public int TeacherParticipantsCount { get; set; }
    public string? AwardDetails { get; set; }
    public string? CertificatePath { get; set; }
    public string? PhotosPathJson { get; set; }
    public string? VideoPath { get; set; }
    public string? Impact { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// المشاركات والتمثيل الخارجي - extracted from ZIP ERD ExternalParticipations (lines 9147-9174).
/// </summary>
public class ExternalParticipation : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ParticipationNumber { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string? EventType { get; set; } // Sports, Scientific, Cultural, Artistic, Volunteer, Academic
    public string? Organizer { get; set; }
    public string? OrganizerType { get; set; }
    public string? Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Results { get; set; }
    public string? Ranking { get; set; }
    public string? ParticipantsJson { get; set; }
    public int StudentParticipantsCount { get; set; }
    public int TeacherParticipantsCount { get; set; }
    public string? ExpensesJson { get; set; }
    public string? FundingSource { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? LessonsLearned { get; set; }
    public string? Recommendations { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// الشراكات المجتمعية - extracted from ZIP ERD CommunityPartnerships (lines 9176-9204).
/// </summary>
public class CommunityPartnership : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PartnershipNumber { get; set; } = string.Empty;
    public string PartnerName { get; set; } = string.Empty;
    public string? PartnerType { get; set; } // Company, NGO, University, Government, Individual
    public string? SupportType { get; set; } // Equipment, Maintenance, Programs, Financial, Training
    public DateTime? AgreementDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsRenewable { get; set; }
    public string? AgreementDocumentPath { get; set; }
    public decimal SupportValueAmount { get; set; }
    public string? SupportValueCurrency { get; set; }
    public string? SupportInKindJson { get; set; }
    public string? Impact { get; set; }
    public int ImpactRating { get; set; } // 1-5
    public long? ResponsibleEmployeeId { get; set; }
    public string? PartnerContactPerson { get; set; }
    public string? PartnerContactEmail { get; set; }
    public string? PartnerContactPhone { get; set; }
    public int PartnershipStatus { get; set; } = 1; // 1=Active, 2=Ended, 3=Renewed, 4=Cancelled
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual Employee? ResponsibleEmployee { get; set; }
}

/// <summary>
/// تقارير السلامة والأمان - extracted from ZIP ERD SafetySecurityReports (lines 9206-9244).
/// </summary>
public class SafetySecurityReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string? ReportPeriod { get; set; } // Monthly, Quarterly, Annual
    public string? SafetyLevel { get; set; } // Excellent, Good, Acceptable, NeedsImprovement
    public DateTime? ExtinguisherExpiryDate { get; set; }
    public int ExtinguishersCount { get; set; }
    public DateTime? ExtinguishersLastInspection { get; set; }
    public DateTime? ExtinguishersNextInspection { get; set; }
    public string? AlarmSystemStatus { get; set; } // Working, NeedsMaintenance, Broken
    public DateTime? AlarmLastTestDate { get; set; }
    public bool HasEvacuationMaps { get; set; }
    public string? EmergencyExitsStatus { get; set; }
    public int DrillCount { get; set; }
    public string? DrillDatesJson { get; set; }
    public int DrillAverageTimeMinutes { get; set; }
    public string? DrillEvaluation { get; set; }
    public bool SafetyCommitteeFormed { get; set; }
    public string? SafetyCommitteeMembersJson { get; set; }
    public int SafetyTrainingHours { get; set; }
    public int IncidentsCount { get; set; }
    public string? Recommendations { get; set; }
    public string? ActionPlan { get; set; }
    public string? AttachmentsJson { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual SystemUser? ApprovedByUser { get; set; }
}

/// <summary>
/// حالات العجز التعليمي - extracted from ZIP ERD SchoolDeficit (lines 9246-9276).
/// </summary>
public class SchoolDeficit : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string DeficitNumber { get; set; } = string.Empty;
    public string DeficitType { get; set; } = string.Empty; // Classrooms, Teachers, Equipment, Financial, EducationalPrograms, Transport
    public string? DeficitCategory { get; set; } // Quantitative, Qualitative, Temporary, Permanent
    public decimal DeficitAmount { get; set; }
    public decimal RequiredAmount { get; set; }
    public decimal AvailableAmount { get; set; }
    public string? DeficitDescription { get; set; }
    public string? EducationalImpact { get; set; }
    public int ImpactLevel { get; set; } // 1=Low, 2=Medium, 3=High, 4=Critical
    public DateTime DetectionDate { get; set; }
    public long? DetectedByUserId { get; set; }
    public int DeficitStatus { get; set; } = 1; // 1=Active, 2=InProgress, 3=Resolved, 4=Deferred
    public DateTime? StatusUpdateDate { get; set; }
    public string? ProposedSolution { get; set; }
    public decimal EstimatedResolutionCost { get; set; }
    public DateTime? EstimatedResolutionDate { get; set; }
    public DateTime? ActualResolutionDate { get; set; }
    public long? ResolvedByUserId { get; set; }
    public string? ResolutionNotes { get; set; }
    public long? RelatedRemediationPlanId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// حالات الفائض التعليمي - extracted from ZIP ERD SchoolSurplus (lines 9278-9307).
/// </summary>
public class SchoolSurplus : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string SurplusNumber { get; set; } = string.Empty;
    public string SurplusType { get; set; } = string.Empty; // Classrooms, Teachers, Equipment, Budget, Time, Transport
    public string? SurplusCategory { get; set; }
    public decimal SurplusAmount { get; set; }
    public decimal AvailableAmount { get; set; }
    public decimal RequiredAmount { get; set; }
    public string? SurplusDescription { get; set; }
    public string? UtilizationPlan { get; set; }
    public string? UtilizationType { get; set; } // TransferToSchool, Leasing, InternalRedistribution, Sale, Decommission
    public string? PotentialBeneficiary { get; set; }
    public DateTime DiscoveryDate { get; set; }
    public long? DiscoveredByUserId { get; set; }
    public int SurplusStatus { get; set; } = 1; // 1=Discovered, 2=InProgress, 3=Utilized, 4=Cancelled
    public DateTime? StatusUpdateDate { get; set; }
    public DateTime? UtilizationDate { get; set; }
    public DateTime? ActualUtilizationDate { get; set; }
    public long? UtilizedByUserId { get; set; }
    public string? UtilizationNotes { get; set; }
    public long? RelatedRemediationPlanId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// خطط معالجة العجز أو الفائض - extracted from ZIP ERD RemediationPlan (lines 9309-9343).
/// </summary>
public class RemediationPlan : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PlanNumber { get; set; } = string.Empty;
    public string PlanName { get; set; } = string.Empty;
    public long? RelatedDeficitId { get; set; }
    public long? RelatedSurplusId { get; set; }
    public int PlanType { get; set; } // 1=DeficitRemediation, 2=SurplusUtilization
    public string? SelectedOption { get; set; } // Expansion, Merger, Transfer, Partnership, Outsourcing, Redistribution
    public string? OptionDetails { get; set; }
    public string? Objectives { get; set; }
    public string? ActionStepsJson { get; set; }
    public DateTime? PlannedStartDate { get; set; }
    public DateTime? PlannedEndDate { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal ActualCost { get; set; }
    public string? Currency { get; set; }
    public long? ExecutionLeadEmployeeId { get; set; }
    public string? ExecutionTeamJson { get; set; }
    public decimal ProgressPercentage { get; set; }
    public int PlanStatus { get; set; } = 1; // 1=Drafting, 2=Approved, 3=InProgress, 4=Completed, 5=Cancelled, 6=Stalled
    public DateTime? ApprovalDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? CompletionReport { get; set; }
    public string? LessonsLearned { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual SchoolDeficit? SchoolDeficit { get; set; }
    public virtual SchoolSurplus? SchoolSurplus { get; set; }
    public virtual Employee? ExecutionLeadEmployee { get; set; }
    public virtual SystemUser? ApprovedByUser { get; set; }
}

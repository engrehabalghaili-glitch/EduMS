using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SafetySecurityReports;

public class CreateSafetySecurityReportDto
{
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string? ReportPeriod { get; set; }
    public string? SafetyLevel { get; set; }
    public DateTime? ExtinguisherExpiryDate { get; set; }
    public int ExtinguishersCount { get; set; }
    public DateTime? ExtinguishersLastInspection { get; set; }
    public DateTime? ExtinguishersNextInspection { get; set; }
    public string? AlarmSystemStatus { get; set; }
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
}

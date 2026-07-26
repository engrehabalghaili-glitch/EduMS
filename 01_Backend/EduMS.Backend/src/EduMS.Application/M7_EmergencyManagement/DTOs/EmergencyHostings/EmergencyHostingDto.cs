using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyHostings;

public class EmergencyHostingDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string HostingNumber { get; set; } = string.Empty;
    public string HostingType { get; set; } = string.Empty;
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
    public int HostingStatus { get; set; } = 1;
    public string? ClosureNotes { get; set; }
    public string? LessonsLearned { get; set; }
    public long? ReportedByUserId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}

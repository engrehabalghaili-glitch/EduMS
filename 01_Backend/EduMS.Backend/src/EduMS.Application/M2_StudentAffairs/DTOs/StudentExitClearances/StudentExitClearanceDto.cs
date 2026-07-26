using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;

public class StudentExitClearanceDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string ClearanceReferenceNumber { get; set; } = string.Empty;
    public int ClearanceReason { get; set; }
    public DateTime InitiationDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public bool IsLibraryClearanceApproved { get; set; }
    public bool IsFinancialClearanceApproved { get; set; }
    public bool IsCanteenClearanceApproved { get; set; }
    public bool IsSportsEquipmentClearanceApproved { get; set; }
    public int OverallClearanceStatus { get; set; }
    public long? ApprovedByDirectorEmployeeId { get; set; }
    public string? ClearanceNotes { get; set; }

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

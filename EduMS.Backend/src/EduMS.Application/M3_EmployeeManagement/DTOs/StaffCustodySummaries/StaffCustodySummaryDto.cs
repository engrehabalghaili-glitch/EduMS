using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;

public class StaffCustodySummaryDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public string? CustodySummaryJson { get; set; }
    public decimal TotalItemsCount { get; set; }
    public decimal TotalEstimatedValue { get; set; }
    public DateTime? CustodyIssuedDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public int CustodyStatus { get; set; } = 1;
    public DateTime? ClearanceDate { get; set; }
    public long? ClearedByUserId { get; set; }
    public string? ClearanceNotes { get; set; }
    public string? ClearanceDocumentUrl { get; set; }
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

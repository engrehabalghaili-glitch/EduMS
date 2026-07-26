using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;

public class SchoolMergerDto
{
    public long Id { get; set; }
    public string MergerNumber { get; set; } = string.Empty;
    public DateTime MergerDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string SourceSchoolIdsJson { get; set; } = string.Empty;
    public long TargetSchoolId { get; set; }
    public string? MergerReason { get; set; }
    public string? DecisionAuthority { get; set; }
    public string? DecisionDocumentPath { get; set; }
    public int StudentsTransferStatus { get; set; }
    public int EmployeesTransferStatus { get; set; }
    public int AssetsTransferStatus { get; set; }
    public int MergerStatus { get; set; } = 1;
    public DateTime? CompletionDate { get; set; }
    public string? CompletionNotes { get; set; }
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

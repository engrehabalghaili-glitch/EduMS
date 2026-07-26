using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;

public class StudentTransferLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long FromSchoolId { get; set; }
    public long ToSchoolId { get; set; }
    public DateTime TransferDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public int Status { get; set; }
    public string? TransferCertificateNumber { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public string? MinistryApprovalReference { get; set; }
    public string? TransferRemarks { get; set; }

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

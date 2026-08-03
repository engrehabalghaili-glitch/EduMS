using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeDocuments;

public class EmployeeDocumentDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string? DocumentSubType { get; set; }
    public string DocumentName { get; set; } = string.Empty;
    public string? DocumentNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? IssuedBy { get; set; }
    public bool IsExpiryRequired { get; set; }
    public bool ExpiryReminderSent { get; set; }
    public string? FilePath { get; set; }
    public long? FileSize { get; set; }
    public string? FileType { get; set; }
    public string? ThumbnailPath { get; set; }
    public string? Description { get; set; }
    public bool IsRequired { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerificationDate { get; set; }
    public string? VerificationNotes { get; set; }
    public string? RejectionReason { get; set; }
    public int DocumentStatus { get; set; } = 1;
    public bool IsConfidential { get; set; }
    public bool IsArchived { get; set; }
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

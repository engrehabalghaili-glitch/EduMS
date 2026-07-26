using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;

public class StudentIdentityDocumentDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public int DocumentType { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? IssueCountry { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? AttachmentUrl { get; set; }
    public bool IsVerified { get; set; }
    public string? IssuePlace { get; set; }
    public long? VerifiedByEmployeeId { get; set; }
    public DateTime? VerificationDate { get; set; }
    public int DocumentStatus { get; set; }

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

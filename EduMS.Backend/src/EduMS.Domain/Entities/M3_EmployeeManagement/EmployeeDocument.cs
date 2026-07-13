using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// مستندات ووثائق الموظف - Employee document archive extracted from ZIP ERD EmployeeDocuments table.
/// </summary>
public class EmployeeDocument : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public string DocumentType { get; set; } = string.Empty; // NationalId, Passport, Residence, Degree, Contract, CV
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
    public int DocumentStatus { get; set; } = 1; // 1=Uploaded, 2=UnderReview, 3=Accepted, 4=Rejected, 5=Expired
    public bool IsConfidential { get; set; }
    public bool IsArchived { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}

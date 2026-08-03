using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;

public class UpdateStudentIdentityDocumentDto
{
    public long Id { get; set; }
    public int DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string? IssueCountry { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? AttachmentUrl { get; set; }
    public bool IsVerified { get; set; }
    public string? IssuePlace { get; set; }
    public long? VerifiedByEmployeeId { get; set; }
    public DateTime? VerificationDate { get; set; }
}

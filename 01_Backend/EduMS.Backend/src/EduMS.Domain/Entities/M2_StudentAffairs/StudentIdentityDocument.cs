using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentIdentityDocument : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public int DocumentType { get; set; } // 1=NationalId, 2=Passport, 3=BirthCertificate, 4=ResidencePermit, 5=FamilyCard
    public string DocumentNumber { get; set; } = string.Empty;
    public string? IssueCountry { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? AttachmentUrl { get; set; }
    public bool IsVerified { get; set; } = false;
    public string? IssuePlace { get; set; }
    public long? VerifiedByEmployeeId { get; set; }
    public DateTime? VerificationDate { get; set; }
    public int DocumentStatus { get; set; } = 1; // 1=Valid, 2=Expired, 3=PendingReview, 4=Rejected

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual Employee? VerifiedByEmployee { get; set; }
}

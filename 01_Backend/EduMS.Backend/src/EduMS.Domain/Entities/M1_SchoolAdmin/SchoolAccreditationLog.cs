using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolAccreditationLog : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public string AccreditationBody { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Status { get; set; } // 1=Active, 2=Expired, 3=Suspended
    public int LicenseType { get; set; } = 1; // 1=Academic, 2=Safety, 3=Municipal, 4=Ministry
    public string? AccreditationGrade { get; set; }
    public string? CertificateAttachmentUrl { get; set; }
    public DateTime? RenewalSubmittedDate { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
}

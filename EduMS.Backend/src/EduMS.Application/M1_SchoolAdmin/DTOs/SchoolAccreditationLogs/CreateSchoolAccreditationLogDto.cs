using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAccreditationLogs;

public class CreateSchoolAccreditationLogDto
{
    public long SchoolId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public string AccreditationBody { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Status { get; set; }
    public int LicenseType { get; set; } = 1;
    public string? AccreditationGrade { get; set; }
    public string? CertificateAttachmentUrl { get; set; }
    public DateTime? RenewalSubmittedDate { get; set; }
}

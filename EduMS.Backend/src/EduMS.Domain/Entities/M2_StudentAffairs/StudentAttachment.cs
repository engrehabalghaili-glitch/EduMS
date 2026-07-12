using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentAttachment : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string AttachmentTitleAr { get; set; } = string.Empty;
    public int AttachmentCategory { get; set; } // 1=AcademicTranscript, 2=MedicalCertificate, 3=ConductReport, 4=Other
    public string FileName { get; set; } = string.Empty;
    public string FilePathUrl { get; set; } = string.Empty;
    public long FileSizeKb { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public string? AttachmentTitleEn { get; set; }
    public string? MimeType { get; set; }
    public bool IsConfidential { get; set; }
    public long? UploadedByEmployeeId { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}

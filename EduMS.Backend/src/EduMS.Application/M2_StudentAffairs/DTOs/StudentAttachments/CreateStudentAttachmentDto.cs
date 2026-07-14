using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;

public class CreateStudentAttachmentDto
{
    public long StudentId { get; set; }
    public string AttachmentTitleAr { get; set; } = string.Empty;
    public int AttachmentCategory { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePathUrl { get; set; } = string.Empty;
    public long FileSizeKb { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public string? AttachmentTitleEn { get; set; }
    public string? MimeType { get; set; }
    public bool IsConfidential { get; set; }
    public long? UploadedByEmployeeId { get; set; }
}

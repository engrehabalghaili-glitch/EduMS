using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;

public class UpdateStudentAttachmentDto
{
    public long Id { get; set; }
    public string AttachmentTitleAr { get; set; }
    public int AttachmentCategory { get; set; }
    public string FileName { get; set; }
    public string FilePathUrl { get; set; }
    public long FileSizeKb { get; set; }
    public DateTime UploadDate { get; set; }
    public string? AttachmentTitleEn { get; set; }
    public string? MimeType { get; set; }
    public bool IsConfidential { get; set; }
    public long? UploadedByEmployeeId { get; set; }
}

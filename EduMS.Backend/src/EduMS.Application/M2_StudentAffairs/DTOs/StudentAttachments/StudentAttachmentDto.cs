using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;

public class StudentAttachmentDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string AttachmentTitleAr { get; set; } = string.Empty;
    public int AttachmentCategory { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePathUrl { get; set; } = string.Empty;
    public long FileSizeKb { get; set; }
    public DateTime UploadDate { get; set; }
    public string? AttachmentTitleEn { get; set; }
    public string? MimeType { get; set; }
    public bool IsConfidential { get; set; }
    public long? UploadedByEmployeeId { get; set; }

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

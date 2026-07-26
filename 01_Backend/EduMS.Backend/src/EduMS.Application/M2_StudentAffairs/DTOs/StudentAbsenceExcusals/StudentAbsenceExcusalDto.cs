using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;

public class StudentAbsenceExcusalDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ExcusalType { get; set; }
    public string ReasonDescription { get; set; } = string.Empty;
    public string? MedicalReportAttachmentUrl { get; set; }
    public int ReviewStatus { get; set; }
    public long? ReviewedByEmployeeId { get; set; }
    public long? SubmittedByGuardianId { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string? ReviewRemarks { get; set; }

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

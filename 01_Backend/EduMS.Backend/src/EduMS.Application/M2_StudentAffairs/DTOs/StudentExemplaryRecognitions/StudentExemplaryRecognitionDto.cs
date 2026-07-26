using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;

public class StudentExemplaryRecognitionDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public string RecognitionTitleAr { get; set; } = string.Empty;
    public int Category { get; set; }
    public DateTime AwardDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? RecognitionTitleEn { get; set; }
    public string? AwardGrantedBy { get; set; }
    public int MeritBonusPoints { get; set; }
    public bool IsFeaturedInSchoolBoard { get; set; }

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

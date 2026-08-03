using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;

public class StudentPreviousAcademicHistoryDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string PreviousSchoolName { get; set; } = string.Empty;
    public string PreviousDirectorateName { get; set; } = string.Empty;
    public string AcademicYearCompleted { get; set; } = string.Empty;
    public int GradeLevelCompleted { get; set; }
    public decimal CumulativeScoreEarned { get; set; }
    public decimal MaximumPossibleScore { get; set; }
    public decimal PercentagePercentage { get; set; }
    public string? LeavingCertificateNumber { get; set; }
    public DateTime LeavingDate { get; set; }
    public int VerificationStatus { get; set; }
    public string? TranscriptDocumentUrl { get; set; }

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

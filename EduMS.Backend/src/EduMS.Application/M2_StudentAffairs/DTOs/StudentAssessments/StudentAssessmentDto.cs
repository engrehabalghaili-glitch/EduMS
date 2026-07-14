using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;

public class StudentAssessmentDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public string AssessmentTitle { get; set; } = string.Empty;
    public int AssessmentCategory { get; set; }
    public decimal MaxScore { get; set; }
    public decimal ObtainedScore { get; set; }
    public DateTime AssessmentDate { get; set; }
    public long? EvaluatedByEmployeeId { get; set; }
    public decimal PassingScore { get; set; }
    public string? LetterCodeResult { get; set; }
    public decimal GradePointResult { get; set; }
    public string? Remarks { get; set; }
    public bool IsRetakeExam { get; set; }
    public long? OriginalAssessmentId { get; set; }

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

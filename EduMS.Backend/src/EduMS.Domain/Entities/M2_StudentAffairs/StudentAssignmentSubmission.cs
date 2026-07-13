using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentAssignmentSubmission : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public string AssignmentTitle { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public int SubmissionStatus { get; set; } // 1=SubmittedOnTime, 2=SubmittedLate, 3=NotSubmitted
    public decimal? ScoreObtained { get; set; }
    public string? TeacherFeedback { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public decimal MaxPossibleScore { get; set; } = 10.0m;
    public int SubmissionAttemptNumber { get; set; } = 1;
    public bool IsGraded { get; set; }
    public long? GradedByEmployeeId { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Employee? GradedByEmployee { get; set; }
}

using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentAssessment : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public string AssessmentTitle { get; set; } = string.Empty;
    public int AssessmentCategory { get; set; } // 1=Monthly, 2=Midterm, 3=Final, 4=Project
    public decimal MaxScore { get; set; } = 100.0m;
    public decimal ObtainedScore { get; set; }
    public DateTime AssessmentDate { get; set; }
    public long? EvaluatedByEmployeeId { get; set; }
    public decimal PassingScore { get; set; } = 50.0m;
    public string? LetterCodeResult { get; set; }
    public decimal GradePointResult { get; set; }
    public string? Remarks { get; set; }
    public bool IsRetakeExam { get; set; }
    public long? OriginalAssessmentId { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Employee? EvaluatedByEmployee { get; set; }
}

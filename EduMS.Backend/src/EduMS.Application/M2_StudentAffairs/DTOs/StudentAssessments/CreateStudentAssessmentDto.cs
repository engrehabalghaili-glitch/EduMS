using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;

public class CreateStudentAssessmentDto
{
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public string AssessmentTitle { get; set; }
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
}

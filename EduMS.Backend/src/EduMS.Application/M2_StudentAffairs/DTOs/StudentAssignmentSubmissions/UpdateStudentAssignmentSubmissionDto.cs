using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;

public class UpdateStudentAssignmentSubmissionDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public string AssignmentTitle { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public int SubmissionStatus { get; set; }
    public decimal? ScoreObtained { get; set; }
    public string? TeacherFeedback { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public decimal MaxPossibleScore { get; set; }
    public int SubmissionAttemptNumber { get; set; }
    public bool IsGraded { get; set; }
    public long? GradedByEmployeeId { get; set; }
}

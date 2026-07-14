using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;

public class CreateStudentEnrollmentDto
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int EnrollmentStatus { get; set; }
    public bool IsCurrentTerm { get; set; } = true;
    public int EnrollmentType { get; set; } = 1;
    public int AssignedRollNumber { get; set; }
    public int PromotionStatus { get; set; } = 1;
    public string? EnrollmentRemarks { get; set; }
}

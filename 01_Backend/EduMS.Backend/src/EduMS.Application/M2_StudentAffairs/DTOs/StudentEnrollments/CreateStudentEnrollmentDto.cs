using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;

public class CreateStudentEnrollmentDto
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public string AcademicYear { get; set; }
    public int SemesterNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public bool IsCurrentTerm { get; set; }
    public int EnrollmentType { get; set; }
    public int AssignedRollNumber { get; set; }
    public string? EnrollmentRemarks { get; set; }
}

using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;

public class UpdateClassSectionDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? ClassroomId { get; set; }
    public string SectionCode { get; set; } = string.Empty;
    public string SectionNameAr { get; set; } = string.Empty;
    public string? SectionNameEn { get; set; }
    public int MaxStudents { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public long? ShiftId { get; set; }
    public int SectionStatus { get; set; }
    public bool IsActive { get; set; }
}

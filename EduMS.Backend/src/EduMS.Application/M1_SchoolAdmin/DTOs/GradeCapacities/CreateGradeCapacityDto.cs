using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;

public class CreateGradeCapacityDto
{
    public long SchoolAcademicYearId { get; set; }
    public long SchoolLevelId { get; set; }
    public string GradeLevelCode { get; set; }
    public string GradeNameAr { get; set; }
    public string? GradeNameEn { get; set; }
    public int MaxStudentsPerSection { get; set; }
    public int MaxSectionsCount { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public int GenderAllocation { get; set; }
    public string? Notes { get; set; }
}

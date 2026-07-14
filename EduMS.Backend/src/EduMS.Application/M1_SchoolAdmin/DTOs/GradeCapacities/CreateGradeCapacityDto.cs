using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;

public class CreateGradeCapacityDto
{
    public long SchoolAcademicYearId { get; set; }
    public long SchoolLevelId { get; set; }
    public string GradeLevelCode { get; set; } = string.Empty;
    public string GradeNameAr { get; set; } = string.Empty;
    public string? GradeNameEn { get; set; }
    public int MaxStudentsPerSection { get; set; }
    public int MaxSectionsCount { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public int GenderAllocation { get; set; } = 1;
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

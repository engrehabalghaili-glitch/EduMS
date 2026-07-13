using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;

public class CreateSchoolLevelDto
{
    public long SchoolId { get; set; }
    public string LevelNameAr { get; set; }
    public string? LevelNameEn { get; set; }
    public int LevelOrder { get; set; }
    public string StartGrade { get; set; }
    public string EndGrade { get; set; }
    public string? AcademicTrack { get; set; }
    public int MinAgeYears { get; set; }
    public int MaxAgeYears { get; set; }
    public long? DefaultShiftId { get; set; }
    public string? Notes { get; set; }
}

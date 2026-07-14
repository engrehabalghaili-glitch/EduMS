using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;

public class UpdateSchoolLevelDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string LevelNameAr { get; set; } = string.Empty;
    public string? LevelNameEn { get; set; }
    public int LevelOrder { get; set; }
    public string StartGrade { get; set; } = string.Empty;
    public string EndGrade { get; set; } = string.Empty;
    public string? AcademicTrack { get; set; }
    public int MinAgeYears { get; set; }
    public int MaxAgeYears { get; set; }
    public long? DefaultShiftId { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
}

using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;

public class CreateDetailedAcademicWarningLogDto
{
    public long StudentId { get; set; }
    public DateTime WarningDate { get; set; } = DateTime.UtcNow;
    public int WarningCategory { get; set; }
    public long? SubjectId { get; set; }
    public int WarningLevel { get; set; }
    public string TriggerDescription { get; set; } = string.Empty;
    public DateTime? GuardianAcknowledgedDate { get; set; }
    public long? IssuedByEmployeeId { get; set; }
    public string? RemedialPlanDescription { get; set; }
    public DateTime? TargetResolutionDate { get; set; }
    public int Status { get; set; } = 1;
    public bool IsEscalatedToDirector { get; set; }
}

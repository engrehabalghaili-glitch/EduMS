using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;

public class CreateBehavioralLogDto
{
    public long StudentId { get; set; }
    public DateTime IncidentDate { get; set; }
    public int BehaviorCategory { get; set; }
    public string IncidentTitleAr { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ActionTaken { get; set; }
    public long? RecordedByEmployeeId { get; set; }
    public int Status { get; set; }
    public string? IncidentTitleEn { get; set; }
    public int DemeritOrMeritPoints { get; set; }
    public string? IncidentLocation { get; set; }
    public int ParentNotificationStatus { get; set; } = 1;
    public string? InvestigationNotes { get; set; }
}

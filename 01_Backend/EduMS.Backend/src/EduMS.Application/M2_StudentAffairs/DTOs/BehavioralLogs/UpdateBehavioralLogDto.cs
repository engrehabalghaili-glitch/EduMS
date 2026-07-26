using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;

public class UpdateBehavioralLogDto
{
    public long Id { get; set; }
    public DateTime IncidentDate { get; set; }
    public int BehaviorCategory { get; set; }
    public string IncidentTitleAr { get; set; }
    public string Description { get; set; }
    public string? ActionTaken { get; set; }
    public string? IncidentTitleEn { get; set; }
    public int DemeritOrMeritPoints { get; set; }
    public string? IncidentLocation { get; set; }
    public string? InvestigationNotes { get; set; }
}

using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.ExternalParticipations;

public class UpdateExternalParticipationDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ParticipationNumber { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string? EventType { get; set; }
    public string? Organizer { get; set; }
    public string? OrganizerType { get; set; }
    public string? Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Results { get; set; }
    public string? Ranking { get; set; }
    public string? ParticipantsJson { get; set; }
    public int StudentParticipantsCount { get; set; }
    public int TeacherParticipantsCount { get; set; }
    public string? ExpensesJson { get; set; }
    public string? FundingSource { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? LessonsLearned { get; set; }
    public string? Recommendations { get; set; }
    public string? Notes { get; set; }
}

using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;

public class UpdateStudentActivityParticipationDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public string ActivityNameAr { get; set; } = string.Empty;
    public int ActivityType { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public DateTime ParticipationDate { get; set; }
    public string? AchievementDetail { get; set; }
    public decimal ScoreBonus { get; set; }
    public string? ActivityNameEn { get; set; }
    public string? ParticipationRole { get; set; }
    public int TotalHoursLogged { get; set; }
    public string? AwardLevel { get; set; }
}

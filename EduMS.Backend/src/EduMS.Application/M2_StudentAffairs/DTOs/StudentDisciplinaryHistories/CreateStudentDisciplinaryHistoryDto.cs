using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;

public class CreateStudentDisciplinaryHistoryDto
{
    public long StudentId { get; set; }
    public long? BehavioralLogId { get; set; }
    public string DisciplinaryActionCode { get; set; } = string.Empty;
    public string ActionTitleAr { get; set; } = string.Empty;
    public DateTime ExecutionDate { get; set; } = DateTime.UtcNow;
    public long? ExecutedByEmployeeId { get; set; }
    public int PenaltyDurationDays { get; set; }
    public DateTime? GuardianNotifiedDate { get; set; }
    public int AppealStatus { get; set; }
    public string? ActionTitleEn { get; set; }
    public string? AppealNotes { get; set; }
    public string? ReinstatementCondition { get; set; }
    public int Status { get; set; } = 1;
}

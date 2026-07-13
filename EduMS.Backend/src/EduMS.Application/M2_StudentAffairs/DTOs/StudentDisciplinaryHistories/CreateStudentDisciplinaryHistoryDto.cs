using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;

public class CreateStudentDisciplinaryHistoryDto
{
    public long StudentId { get; set; }
    public long? BehavioralLogId { get; set; }
    public string DisciplinaryActionCode { get; set; }
    public string ActionTitleAr { get; set; }
    public DateTime ExecutionDate { get; set; }
    public long? ExecutedByEmployeeId { get; set; }
    public int PenaltyDurationDays { get; set; }
    public DateTime? GuardianNotifiedDate { get; set; }
    public string? ActionTitleEn { get; set; }
    public string? AppealNotes { get; set; }
    public string? ReinstatementCondition { get; set; }
}

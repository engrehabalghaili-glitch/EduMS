using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;

public class CreateClassroomOperationalRuleDto
{
    public long ClassroomId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleTitleAr { get; set; } = string.Empty;
    public string RuleTitleEn { get; set; } = string.Empty;
    public decimal MaxAllowedAbsencePercentage { get; set; } = 15.0m;
    public bool RequiresDailyAttendanceLog { get; set; } = true;
    public int AllowLateArrivalMinutes { get; set; } = 15;
    public int MaxAllowedConsecutiveAbsenceDays { get; set; } = 5;
    public int PenaltyTypeForExceedingLimit { get; set; } = 1;
    public DateTime? EffectiveStartDate { get; set; }
    public bool IsActive { get; set; } = true;
}

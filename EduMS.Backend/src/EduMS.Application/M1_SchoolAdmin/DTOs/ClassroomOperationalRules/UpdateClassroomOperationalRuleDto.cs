using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;

public class UpdateClassroomOperationalRuleDto
{
    public long Id { get; set; }
    public long ClassroomId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleTitleAr { get; set; } = string.Empty;
    public string RuleTitleEn { get; set; } = string.Empty;
    public decimal MaxAllowedAbsencePercentage { get; set; }
    public bool RequiresDailyAttendanceLog { get; set; }
    public int AllowLateArrivalMinutes { get; set; }
    public int MaxAllowedConsecutiveAbsenceDays { get; set; }
    public int PenaltyTypeForExceedingLimit { get; set; }
    public DateTime? EffectiveStartDate { get; set; }
    public bool IsActive { get; set; }
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;

public class CreateClassroomOperationalRuleDto
{
    public long ClassroomId { get; set; }
    public string RuleCode { get; set; }
    public string RuleTitleAr { get; set; }
    public string RuleTitleEn { get; set; }
    public decimal MaxAllowedAbsencePercentage { get; set; }
    public bool RequiresDailyAttendanceLog { get; set; }
    public int AllowLateArrivalMinutes { get; set; }
    public int MaxAllowedConsecutiveAbsenceDays { get; set; }
    public int PenaltyTypeForExceedingLimit { get; set; }
    public DateTime? EffectiveStartDate { get; set; }
}

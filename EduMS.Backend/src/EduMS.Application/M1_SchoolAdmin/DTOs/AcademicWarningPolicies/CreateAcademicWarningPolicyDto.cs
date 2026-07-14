using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;

public class CreateAcademicWarningPolicyDto
{
    public long SchoolId { get; set; }
    public string PolicyCode { get; set; }
    public string PolicyTitleAr { get; set; }
    public int WarningCategory { get; set; }
    public decimal ThresholdValue { get; set; }
    public int ActionRequired { get; set; }
    public string? PolicyTitleEn { get; set; }
    public int ConsecutiveOccurrenceLimit { get; set; }
    public bool AutoTriggerNotification { get; set; }
    public long? EscalationPolicyId { get; set; }
}

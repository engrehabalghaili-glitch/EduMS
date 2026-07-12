using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class AcademicWarningPolicy : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PolicyCode { get; set; } = string.Empty;
    public string PolicyTitleAr { get; set; } = string.Empty;
    public int WarningCategory { get; set; } // 1=AcademicGrade, 2=AbsenceCount, 3=BehavioralInfraction
    public decimal ThresholdValue { get; set; } // e.g. 50.0m for grade, 15.0m for absence
    public int ActionRequired { get; set; } // 1=ParentNotification, 2=CounselorMeeting, 3=Suspension
    public string? PolicyTitleEn { get; set; }
    public int ConsecutiveOccurrenceLimit { get; set; }
    public bool AutoTriggerNotification { get; set; } = true;
    public long? EscalationPolicyId { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
}

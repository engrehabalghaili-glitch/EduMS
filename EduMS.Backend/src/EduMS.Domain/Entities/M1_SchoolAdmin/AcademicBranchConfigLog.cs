using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class AcademicBranchConfigLog : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ConfigKey { get; set; } = string.Empty;
    public string ConfigValue { get; set; } = string.Empty;
    public string? PreviousValue { get; set; }
    public string? ChangeReason { get; set; }
    public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
    public int ConfigCategory { get; set; } = 1; // 1=Academic, 2=Attendance, 3=Grading, 4=Security
    public long? ModifiedByEmployeeId { get; set; }
    public bool RequiresSupervisoryApproval { get; set; }
    public int ApprovalStatus { get; set; } = 2; // 1=Pending, 2=Approved, 3=Rejected
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;

public class UpdateAcademicBranchConfigLogDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ConfigKey { get; set; } = string.Empty;
    public string ConfigValue { get; set; } = string.Empty;
    public string? PreviousValue { get; set; }
    public string? ChangeReason { get; set; }
    public DateTime EffectiveDate { get; set; }
    public int ConfigCategory { get; set; }
    public long? ModifiedByEmployeeId { get; set; }
    public bool RequiresSupervisoryApproval { get; set; }
    public int ApprovalStatus { get; set; }
    public bool IsActive { get; set; }
}

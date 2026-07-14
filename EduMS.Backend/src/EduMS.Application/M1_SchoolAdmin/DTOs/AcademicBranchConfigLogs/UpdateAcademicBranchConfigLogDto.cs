namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;

public class UpdateAcademicBranchConfigLogDto
{
    public long Id { get; set; }
    public string ConfigValue { get; set; }
    public string? ChangeReason { get; set; }
    public int ConfigCategory { get; set; }
    public bool RequiresSupervisoryApproval { get; set; }
}

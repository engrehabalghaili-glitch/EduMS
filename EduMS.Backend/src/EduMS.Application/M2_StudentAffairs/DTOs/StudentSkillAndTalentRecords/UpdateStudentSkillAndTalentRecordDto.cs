using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;

public class UpdateStudentSkillAndTalentRecordDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public int TalentCategory { get; set; }
    public string TalentTitleAr { get; set; } = string.Empty;
    public int ProficiencyLevel { get; set; }
    public DateTime DiscoveredDate { get; set; }
    public long? MentorEmployeeId { get; set; }
    public string? TalentTitleEn { get; set; }
    public string? DevelopmentPlanDescription { get; set; }
    public string? PortfolioAttachmentUrl { get; set; }
    public bool IsEnrolledInGiftedProgram { get; set; }
}

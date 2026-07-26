using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentSkillAndTalentRecord : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public int TalentCategory { get; set; } // 1=ScientificResearch, 2=Artistic, 3=Athletic, 4=Literary, 5=Coding
    public string TalentTitleAr { get; set; } = string.Empty;
    public int ProficiencyLevel { get; set; } // 1=Beginner, 2=Intermediate, 3=Advanced, 4=NationalLevel
    public DateTime DiscoveredDate { get; set; } = DateTime.UtcNow;
    public long? MentorEmployeeId { get; set; }
    public string? TalentTitleEn { get; set; }
    public string? DevelopmentPlanDescription { get; set; }
    public string? PortfolioAttachmentUrl { get; set; }
    public bool IsEnrolledInGiftedProgram { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Employee? MentorEmployee { get; set; }
}

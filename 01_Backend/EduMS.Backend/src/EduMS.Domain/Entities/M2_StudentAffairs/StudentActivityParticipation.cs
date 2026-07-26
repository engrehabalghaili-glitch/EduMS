using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentActivityParticipation : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public string ActivityNameAr { get; set; } = string.Empty;
    public int ActivityType { get; set; } // 1=Sports, 2=Cultural, 3=Scientific, 4=CommunityService
    public long? SupervisorEmployeeId { get; set; }
    public DateTime ParticipationDate { get; set; }
    public string? AchievementDetail { get; set; }
    public decimal ScoreBonus { get; set; }
    public string? ActivityNameEn { get; set; }
    public string? ParticipationRole { get; set; } // e.g. Team Leader, Member
    public int TotalHoursLogged { get; set; }
    public string? AwardLevel { get; set; } // e.g. Gold, Silver, Bronze

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
    public virtual Employee? SupervisorEmployee { get; set; }
}

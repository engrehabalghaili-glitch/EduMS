using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentExtracurricularAchievement : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string CompetitionTitleAr { get; set; } = string.Empty;
    public string? CompetitionTitleEn { get; set; }
    public int CompetitionLevel { get; set; } // 1=SchoolLevel, 2=DirectorateLevel, 3=NationalLevel, 4=InternationalLevel
    public string OrganizingInstitutionName { get; set; } = string.Empty;
    public DateTime AchievementDate { get; set; }
    public int RankOrMedalAchieved { get; set; } // 1=GoldFirstPlace, 2=SilverSecondPlace, 3=BronzeThirdPlace, 4=HonorableMention
    public string? AwardDescription { get; set; }
    public decimal MonetaryPrizeAmount { get; set; }
    public long? SupervisingCoachEmployeeId { get; set; }
    public string? CertificateOrMedalPhotoUrl { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual Employee? SupervisingCoachEmployee { get; set; }
}

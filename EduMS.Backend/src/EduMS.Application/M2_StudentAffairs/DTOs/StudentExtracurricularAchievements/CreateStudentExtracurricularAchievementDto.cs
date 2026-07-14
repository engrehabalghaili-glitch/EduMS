using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;

public class CreateStudentExtracurricularAchievementDto
{
    public long StudentId { get; set; }
    public string CompetitionTitleAr { get; set; }
    public string? CompetitionTitleEn { get; set; }
    public int CompetitionLevel { get; set; }
    public string OrganizingInstitutionName { get; set; }
    public DateTime AchievementDate { get; set; }
    public int RankOrMedalAchieved { get; set; }
    public string? AwardDescription { get; set; }
    public decimal MonetaryPrizeAmount { get; set; }
    public long? SupervisingCoachEmployeeId { get; set; }
    public string? CertificateOrMedalPhotoUrl { get; set; }
}

using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentExemplaryRecognition : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public string RecognitionTitleAr { get; set; } = string.Empty;
    public int Category { get; set; } // 1=AcademicExcellence, 2=BehavioralExcellence, 3=CompetitionWinner
    public DateTime AwardDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? RecognitionTitleEn { get; set; }
    public string? AwardGrantedBy { get; set; }
    public int MeritBonusPoints { get; set; }
    public bool IsFeaturedInSchoolBoard { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}

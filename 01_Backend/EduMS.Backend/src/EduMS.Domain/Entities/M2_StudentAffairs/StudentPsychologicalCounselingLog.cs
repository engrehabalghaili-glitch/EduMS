using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentPsychologicalCounselingLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long CounselorEmployeeId { get; set; }
    public DateTime SessionDate { get; set; } = DateTime.UtcNow;
    public int SessionCategory { get; set; } // 1=AcademicStress, 2=BehavioralCounseling, 3=SocialAdaptation
    public string? SessionNotes { get; set; }
    public string? RecommendedIntervention { get; set; }
    public bool IsConfidential { get; set; } = true;
    public DateTime? FollowUpDate { get; set; }
    public int ReferralSource { get; set; } = 1; // 1=Teacher, 2=Parent, 3=Self, 4=DisciplinaryBoard
    public int RiskAssessmentLevel { get; set; } = 1; // 1=Low, 2=Medium, 3=High
    public bool IsParentInvolved { get; set; }
    public int CaseStatus { get; set; } = 1; // 1=Open, 2=UnderIntervention, 3=Closed

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Employee? CounselorEmployee { get; set; }
}

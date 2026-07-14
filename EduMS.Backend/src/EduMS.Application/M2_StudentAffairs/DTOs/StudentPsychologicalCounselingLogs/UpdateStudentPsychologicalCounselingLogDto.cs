using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;

public class UpdateStudentPsychologicalCounselingLogDto
{
    public long Id { get; set; }
    public long CounselorEmployeeId { get; set; }
    public DateTime SessionDate { get; set; }
    public int SessionCategory { get; set; }
    public string? SessionNotes { get; set; }
    public string? RecommendedIntervention { get; set; }
    public bool IsConfidential { get; set; }
    public DateTime? FollowUpDate { get; set; }
    public int ReferralSource { get; set; }
    public int RiskAssessmentLevel { get; set; }
    public bool IsParentInvolved { get; set; }
}

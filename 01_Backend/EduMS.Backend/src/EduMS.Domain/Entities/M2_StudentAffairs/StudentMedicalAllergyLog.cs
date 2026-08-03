using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentMedicalAllergyLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string AllergyOrConditionName { get; set; } = string.Empty;
    public int SeverityLevel { get; set; } // 1=Mild, 2=Moderate, 3=SevereLifeThreatening
    public string? ReactionSymptoms { get; set; }
    public string? EmergencyActionProtocol { get; set; }
    public string? RequiredMedicationName { get; set; }
    public DateTime ReportedDate { get; set; } = DateTime.UtcNow;
    public bool IsEpiPenRequired { get; set; }
    public string? DoctorContactNumber { get; set; }
    public DateTime? LastReactionDate { get; set; }
    public int NurseVerificationStatus { get; set; } = 1; // 1=ReportedByParent, 2=VerifiedByNurse

    // Navigation Property
    public virtual Student? Student { get; set; }
}

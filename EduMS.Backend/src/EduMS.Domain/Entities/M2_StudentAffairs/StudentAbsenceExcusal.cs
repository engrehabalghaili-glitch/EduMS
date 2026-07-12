using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentAbsenceExcusal : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ExcusalType { get; set; } // 1=Medical, 2=FamilyEmergency, 3=OfficialParticipation
    public string ReasonDescription { get; set; } = string.Empty;
    public string? MedicalReportAttachmentUrl { get; set; }
    public int ReviewStatus { get; set; } // 1=Pending, 2=Approved, 3=Rejected
    public long? ReviewedByEmployeeId { get; set; }
    public long? SubmittedByGuardianId { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public string? ReviewRemarks { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Employee? ReviewedByEmployee { get; set; }
}

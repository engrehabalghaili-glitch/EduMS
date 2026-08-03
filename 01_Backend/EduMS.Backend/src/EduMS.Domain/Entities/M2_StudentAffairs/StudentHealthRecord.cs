using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentHealthRecord : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public DateTime RecordDate { get; set; } = DateTime.UtcNow;
    public string? ExaminationDetails { get; set; }
    public string? Diagnosis { get; set; }
    public string? TreatmentPlan { get; set; }
    public string? ReferralHospital { get; set; }
    public string? ExaminedByNurseName { get; set; }
    public int HealthStatus { get; set; } // 1=Stable, 2=RequiresMonitoring, 3=Critical
    public string? HealthRecordCode { get; set; }
    public decimal PhysicalHeightCm { get; set; }
    public decimal PhysicalWeightKg { get; set; }
    public string? VisionCheckResult { get; set; }
    public string? HearingCheckResult { get; set; }
    public bool IsFitForPhysicalEducation { get; set; } = true;
    public DateTime? NextCheckupDate { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}

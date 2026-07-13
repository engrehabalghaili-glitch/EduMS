using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;

public class StudentHealthRecordDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public DateTime RecordDate { get; set; }
    public string? ExaminationDetails { get; set; }
    public string? Diagnosis { get; set; }
    public string? TreatmentPlan { get; set; }
    public string? ReferralHospital { get; set; }
    public string? ExaminedByNurseName { get; set; }
    public int HealthStatus { get; set; }
    public string? HealthRecordCode { get; set; }
    public decimal PhysicalHeightCm { get; set; }
    public decimal PhysicalWeightKg { get; set; }
    public string? VisionCheckResult { get; set; }
    public string? HearingCheckResult { get; set; }
    public bool IsFitForPhysicalEducation { get; set; }
    public DateTime? NextCheckupDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}

using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentHealthRecords;

public class UpdateStudentHealthRecordDto
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
}

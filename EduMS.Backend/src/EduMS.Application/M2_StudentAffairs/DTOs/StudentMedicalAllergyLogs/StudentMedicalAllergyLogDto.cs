using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;

public class StudentMedicalAllergyLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string AllergyOrConditionName { get; set; } = string.Empty;
    public int SeverityLevel { get; set; }
    public string? ReactionSymptoms { get; set; }
    public string? EmergencyActionProtocol { get; set; }
    public string? RequiredMedicationName { get; set; }
    public DateTime ReportedDate { get; set; }
    public bool IsEpiPenRequired { get; set; }
    public string? DoctorContactNumber { get; set; }
    public DateTime? LastReactionDate { get; set; }
    public int NurseVerificationStatus { get; set; }

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

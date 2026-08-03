using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;

public class TrainingCourseOfferingDto
{
    public long Id { get; set; }
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseTitleAr { get; set; } = string.Empty;
    public string? TrainerName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalHours { get; set; }
    public int MaxParticipants { get; set; }
    public decimal CostPerParticipant { get; set; }
    public string? CourseTitleEn { get; set; }
    public string? TrainingLocation { get; set; }
    public string? TargetSpecialization { get; set; }
    public int EnrolledParticipantsCount { get; set; }
    public string? CertificateTemplateUrl { get; set; }
    public bool IsActive { get; set; }

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

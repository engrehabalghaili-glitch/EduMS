using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class TrainingCourseOffering : BaseAuditableEntity
{
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
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
    public virtual School? School { get; set; }
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.TrainingCourseOfferings;

public class UpdateTrainingCourseOfferingDto
{
    public long Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseTitleAr { get; set; }
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
}

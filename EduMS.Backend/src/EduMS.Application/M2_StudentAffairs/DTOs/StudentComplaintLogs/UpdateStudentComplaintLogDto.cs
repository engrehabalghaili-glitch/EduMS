using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentComplaintLogs;

public class UpdateStudentComplaintLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long? SubmittedByGuardianId { get; set; }
    public string ComplaintReferenceNumber { get; set; } = string.Empty;
    public DateTime SubmissionDate { get; set; }
    public int ComplaintCategory { get; set; }
    public string ComplaintTitleAr { get; set; } = string.Empty;
    public string ComplaintDescriptionText { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int ComplaintStatus { get; set; }
    public long? AssignedToEmployeeId { get; set; }
    public DateTime? AssignedDate { get; set; }
    public DateTime? ExpectedResolutionDate { get; set; }
    public DateTime? ActualResolutionDate { get; set; }
    public string? InvestigationNotes { get; set; }
    public string? ResolutionDecisionText { get; set; }
    public bool IsGuardianNotifiedOfResolution { get; set; }
    public DateTime? GuardianNotificationDate { get; set; }
    public int GuardianSatisfactionRating { get; set; }
    public bool IsEscalatedToDirectorate { get; set; }
    public DateTime? EscalationDate { get; set; }
}

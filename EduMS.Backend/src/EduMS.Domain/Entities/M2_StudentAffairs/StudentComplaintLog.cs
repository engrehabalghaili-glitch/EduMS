using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// شكاوى الطلاب وأولياء الأمور - Student/guardian complaint log extracted from ZIP ERD StudentComplaint table.
/// Manages complaint lifecycle: submission → assignment → investigation → resolution → archival.
/// </summary>
public class StudentComplaintLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long? SubmittedByGuardianId { get; set; }
    public string ComplaintReferenceNumber { get; set; } = string.Empty;
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public int ComplaintCategory { get; set; } // 1=AcademicGrading, 2=BehavioralTreatment, 3=AdministrativeService, 4=FinancialFee, 5=FacilityOrTransport
    public string ComplaintTitleAr { get; set; } = string.Empty;
    public string ComplaintDescriptionText { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int ComplaintStatus { get; set; } = 1; // 1=Submitted, 2=UnderInvestigation, 3=Resolved, 4=Rejected, 5=Escalated
    public long? AssignedToEmployeeId { get; set; }
    public DateTime? AssignedDate { get; set; }
    public DateTime? ExpectedResolutionDate { get; set; }
    public DateTime? ActualResolutionDate { get; set; }
    public string? InvestigationNotes { get; set; }
    public string? ResolutionDecisionText { get; set; }
    public bool IsGuardianNotifiedOfResolution { get; set; }
    public DateTime? GuardianNotificationDate { get; set; }
    public int GuardianSatisfactionRating { get; set; } // 1=Unsatisfied, 2=Neutral, 3=Satisfied
    public bool IsEscalatedToDirectorate { get; set; }
    public DateTime? EscalationDate { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Guardian? SubmittedByGuardian { get; set; }
    public virtual Employee? AssignedToEmployee { get; set; }
}

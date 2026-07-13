using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class DirectorateLegalCaseLog : BaseAuditableEntity
{
    public long DirectorateId { get; set; }
    public string CaseCodeNumber { get; set; } = string.Empty;
    public int CaseCategory { get; set; } // 1=LegalDispute, 2=AdministrativeComplaint, 3=RegulatoryInquiry, 4=Consultation
    public string SubjectTitle { get; set; } = string.Empty;
    public string InvolvedPartiesDescription { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime? ResolutionDate { get; set; }
    public int CaseStatus { get; set; } // 1=UnderInvestigation, 2=InCourt, 3=ResolvedClosed, 4=ReferredToMinistry
    public string? ResolutionDecisionText { get; set; }
    public long? AssignedLegalCounselEmployeeId { get; set; }
    public string? CaseDocumentAttachmentUrl { get; set; }

    // Navigation Property
    public virtual Directorate? Directorate { get; set; }
    public virtual Employee? AssignedLegalCounselEmployee { get; set; }
}

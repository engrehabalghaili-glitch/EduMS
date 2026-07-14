using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;

public class CreateDirectorateLegalCaseLogDto
{
    public long DirectorateId { get; set; }
    public string CaseCodeNumber { get; set; } = string.Empty;
    public int CaseCategory { get; set; }
    public string SubjectTitle { get; set; } = string.Empty;
    public string InvolvedPartiesDescription { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime? ResolutionDate { get; set; }
    public int CaseStatus { get; set; }
    public string? ResolutionDecisionText { get; set; }
    public long? AssignedLegalCounselEmployeeId { get; set; }
    public string? CaseDocumentAttachmentUrl { get; set; }
}

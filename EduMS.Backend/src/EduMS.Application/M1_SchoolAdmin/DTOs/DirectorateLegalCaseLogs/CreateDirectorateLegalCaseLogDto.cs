using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;

public class CreateDirectorateLegalCaseLogDto
{
    public long DirectorateId { get; set; }
    public string CaseCodeNumber { get; set; }
    public int CaseCategory { get; set; }
    public string SubjectTitle { get; set; }
    public string InvolvedPartiesDescription { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime? ResolutionDate { get; set; }
    public string? ResolutionDecisionText { get; set; }
    public long? AssignedLegalCounselEmployeeId { get; set; }
    public string? CaseDocumentAttachmentUrl { get; set; }
}

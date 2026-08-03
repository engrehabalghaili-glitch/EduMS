using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;

public class DirectorateLegalCaseLogDto
{
    public long Id { get; set; }
    public long DirectorateId { get; set; }
    public string CaseCodeNumber { get; set; } = string.Empty;
    public int CaseCategory { get; set; }
    public string SubjectTitle { get; set; } = string.Empty;
    public string InvolvedPartiesDescription { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public DateTime? ResolutionDate { get; set; }
    public int CaseStatus { get; set; }
    public string? ResolutionDecisionText { get; set; }
    public long? AssignedLegalCounselEmployeeId { get; set; }
    public string? CaseDocumentAttachmentUrl { get; set; }

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

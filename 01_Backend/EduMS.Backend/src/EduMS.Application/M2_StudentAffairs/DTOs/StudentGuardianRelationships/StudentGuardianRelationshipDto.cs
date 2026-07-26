using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;

public class StudentGuardianRelationshipDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public int RelationshipType { get; set; }
    public bool IsPrimaryContact { get; set; }
    public bool IsEmergencyContact { get; set; }
    public bool HasFinancialResponsibility { get; set; }
    public bool HasLegalCustody { get; set; }
    public string? CustodyDocumentReference { get; set; }
    public bool IsAuthorizedForMedicalDecisions { get; set; }
    public bool IsLivingTogether { get; set; }

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

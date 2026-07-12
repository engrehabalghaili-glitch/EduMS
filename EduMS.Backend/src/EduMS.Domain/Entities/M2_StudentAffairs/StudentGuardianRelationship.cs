using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentGuardianRelationship : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public int RelationshipType { get; set; } // 1=Father, 2=Mother, 3=Grandfather, 4=LegalGuardian
    public bool IsPrimaryContact { get; set; } = true;
    public bool IsEmergencyContact { get; set; } = true;
    public bool HasFinancialResponsibility { get; set; } = true;
    public bool HasLegalCustody { get; set; } = true;
    public string? CustodyDocumentReference { get; set; }
    public bool IsAuthorizedForMedicalDecisions { get; set; } = true;
    public bool IsLivingTogether { get; set; } = true;

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Guardian? Guardian { get; set; }
}

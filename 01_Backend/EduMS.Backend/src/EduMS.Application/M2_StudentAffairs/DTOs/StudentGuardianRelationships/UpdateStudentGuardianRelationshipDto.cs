using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;

public class UpdateStudentGuardianRelationshipDto
{
    public long Id { get; set; }
    public long GuardianId { get; set; }
    public int RelationshipType { get; set; }
    public bool IsPrimaryContact { get; set; }
    public bool IsEmergencyContact { get; set; }
    public bool HasFinancialResponsibility { get; set; }
    public bool HasLegalCustody { get; set; }
    public string? CustodyDocumentReference { get; set; }
    public bool IsAuthorizedForMedicalDecisions { get; set; }
    public bool IsLivingTogether { get; set; }
}

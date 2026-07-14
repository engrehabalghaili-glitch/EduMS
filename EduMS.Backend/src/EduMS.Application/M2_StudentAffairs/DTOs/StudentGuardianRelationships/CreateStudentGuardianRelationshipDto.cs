using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;

public class CreateStudentGuardianRelationshipDto
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public int RelationshipType { get; set; }
    public bool IsPrimaryContact { get; set; } = true;
    public bool IsEmergencyContact { get; set; } = true;
    public bool HasFinancialResponsibility { get; set; } = true;
    public bool HasLegalCustody { get; set; } = true;
    public string? CustodyDocumentReference { get; set; }
    public bool IsAuthorizedForMedicalDecisions { get; set; } = true;
    public bool IsLivingTogether { get; set; } = true;
}

using System;
using EduMS.Application.M2_StudentAffairs.DTOs.Persons;

namespace EduMS.Application.M2_StudentAffairs.DTOs.Guardians;

public class CreateGuardianDto : CreatePersonDto
{
    public string FamilyNumber { get; set; }
    public string RelationshipType { get; set; }
    public string? JobTitle { get; set; }
    public string? EmployerName { get; set; }
    public string? WorkPhoneNumber { get; set; }
    public int EmergencyContactPriority { get; set; }
    public bool IsAuthorizedPickup { get; set; }
    public string? PreferredLanguage { get; set; }
    public string? AnnualIncomeRange { get; set; }
}

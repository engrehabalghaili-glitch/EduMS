using System;
using EduMS.Application.M2_StudentAffairs.DTOs.Persons;

namespace EduMS.Application.M2_StudentAffairs.DTOs.Guardians;

public class GuardianDto : PersonDto
{
    public string FamilyNumber { get; set; } = string.Empty;
    public string RelationshipType { get; set; } = string.Empty;
    public string? JobTitle { get; set; }
    public string? EmployerName { get; set; }
    public string? WorkPhoneNumber { get; set; }
    public int EmergencyContactPriority { get; set; }
    public bool IsAuthorizedPickup { get; set; }
    public string? PreferredLanguage { get; set; }
    public string? AnnualIncomeRange { get; set; }
}

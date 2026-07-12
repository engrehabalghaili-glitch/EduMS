namespace EduMS.Domain.Entities;

public class Guardian : Person
{
    public string FamilyNumber { get; set; } = string.Empty;
    public string RelationshipType { get; set; } = string.Empty; // e.g. Father, Mother, Uncle
    public string? JobTitle { get; set; }
    public string? EmployerName { get; set; }
    public string? WorkPhoneNumber { get; set; }
    public int EmergencyContactPriority { get; set; } = 1;
    public bool IsAuthorizedPickup { get; set; } = true;
    public string? PreferredLanguage { get; set; }
    public string? AnnualIncomeRange { get; set; }

    // Navigation Properties
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<StudentGuardianRelationship> StudentRelationships { get; set; } = new List<StudentGuardianRelationship>();
}

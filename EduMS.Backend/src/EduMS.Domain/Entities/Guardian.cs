namespace EduMS.Domain.Entities;

public class Guardian : Person
{
    public string FamilyNumber { get; set; } = string.Empty;
    public string RelationshipType { get; set; } = string.Empty; // e.g. Father, Mother, Uncle
    public string? JobTitle { get; set; }
}

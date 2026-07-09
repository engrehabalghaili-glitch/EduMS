namespace EduMS.Domain.Entities;

public class Student : Person
{
    public string EnrollmentNumber { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public long? SchoolId { get; set; } // Reference to current School
    public long? GuardianId { get; set; } // Reference to Guardian
    public bool IsActive { get; set; } = true;
}

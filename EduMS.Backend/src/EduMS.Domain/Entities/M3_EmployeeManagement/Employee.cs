namespace EduMS.Domain.Entities;

public class Employee : Person
{
    public string EmployeeNumber { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public decimal BaseSalary { get; set; }
    public DateTime HireDate { get; set; }
    public long? SchoolId { get; set; } // Reference to School
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Departments;

public class CreateDepartmentDto
{
    public long SchoolId { get; set; }
    public string DepartmentCode { get; set; } = string.Empty;
    public string DepartmentNameAr { get; set; } = string.Empty;
    public string DepartmentNameEn { get; set; } = string.Empty;
    public int DepartmentType { get; set; }
    public string? Responsibilities { get; set; }
    public decimal AnnualBudget { get; set; }
    public int EmployeeCount { get; set; }
    public long? HeadOfDepartmentEmployeeId { get; set; }
    public string? WorkingHoursDescription { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public bool IsActive { get; set; } = true;
}

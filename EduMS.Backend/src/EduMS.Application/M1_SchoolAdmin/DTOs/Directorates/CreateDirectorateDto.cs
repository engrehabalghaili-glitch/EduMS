using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;

public class CreateDirectorateDto
{
    public string DirectorateCode { get; set; } = string.Empty;
    public string DirectorateNameAr { get; set; } = string.Empty;
    public string DirectorateNameEn { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? DirectorName { get; set; }
    public string? Governorate { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public string? RegionCode { get; set; }
    public string? SupervisoryScopeDescription { get; set; }
    public decimal AnnualBudgetLimit { get; set; }
    public int EmployeeCount { get; set; }
    public bool IsActive { get; set; } = true;
}

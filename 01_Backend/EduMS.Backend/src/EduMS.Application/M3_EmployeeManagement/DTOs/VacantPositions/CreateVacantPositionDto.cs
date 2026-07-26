using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;

public class CreateVacantPositionDto
{
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string PositionCode { get; set; } = string.Empty;
    public string PositionTitleAr { get; set; } = string.Empty;
    public string? PositionTitleEn { get; set; }
    public long? DepartmentId { get; set; }
    public int EmployeeType { get; set; }
    public string? RequiredQualification { get; set; }
    public int ExperienceRequiredYears { get; set; }
    public decimal SalaryRangeMin { get; set; }
    public decimal SalaryRangeMax { get; set; }
    public int VacancyStatus { get; set; } = 1;
    public DateTime PostingDate { get; set; } = DateTime.UtcNow;
    public DateTime? ClosingDate { get; set; }
    public string? SpecialRequirements { get; set; }
    public string? Notes { get; set; }
}

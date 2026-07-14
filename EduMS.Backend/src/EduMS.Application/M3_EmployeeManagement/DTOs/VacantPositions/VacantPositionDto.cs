using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;

public class VacantPositionDto
{
    public long Id { get; set; }
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
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}

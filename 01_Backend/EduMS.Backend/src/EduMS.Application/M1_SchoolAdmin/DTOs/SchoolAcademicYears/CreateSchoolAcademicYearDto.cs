using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;

public class CreateSchoolAcademicYearDto
{
    public long SchoolId { get; set; }
    public string YearCode { get; set; }
    public string YearNameAr { get; set; }
    public string? YearNameEn { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RegistrationStartDate { get; set; }
    public DateTime RegistrationEndDate { get; set; }
    public DateTime? AddDropStartDate { get; set; }
    public DateTime? AddDropEndDate { get; set; }
    public DateTime? ExamsStartDate { get; set; }
    public DateTime? ExamsEndDate { get; set; }
    public bool IsCurrentYear { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDate { get; set; }
    public long? PreviousAcademicYearId { get; set; }
    public string? Notes { get; set; }
}

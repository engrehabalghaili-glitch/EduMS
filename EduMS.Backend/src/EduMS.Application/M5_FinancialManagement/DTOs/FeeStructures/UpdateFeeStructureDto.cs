using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;

public class UpdateFeeStructureDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string FeeCode { get; set; } = string.Empty;
    public string FeeNameAr { get; set; } = string.Empty;
    public string FeeNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public decimal Amount { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
}

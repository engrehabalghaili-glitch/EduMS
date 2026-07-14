using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;

public class CreateSchoolOperationalBudgetLogDto
{
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public string BudgetCategoryCode { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal ConsumedAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public int Status { get; set; }
    public string? CategoryNameEn { get; set; }
    public int QuarterNumber { get; set; } = 1;
    public long? ApprovedByDirectorId { get; set; }
    public DateTime? LastTransactionDate { get; set; }
    public string? NotesDescription { get; set; }
}

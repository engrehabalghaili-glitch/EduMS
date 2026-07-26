using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;

public class UpdateSchoolOperationalBudgetLogDto
{
    public long Id { get; set; }
    public string FiscalYear { get; set; }
    public string BudgetCategoryCode { get; set; }
    public string CategoryNameAr { get; set; }
    public decimal AllocatedAmount { get; set; }
    public decimal ConsumedAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? CategoryNameEn { get; set; }
    public int QuarterNumber { get; set; }
    public DateTime? LastTransactionDate { get; set; }
    public string? NotesDescription { get; set; }
}

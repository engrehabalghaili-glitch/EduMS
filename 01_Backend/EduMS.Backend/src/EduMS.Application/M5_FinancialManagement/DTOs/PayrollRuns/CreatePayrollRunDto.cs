using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.PayrollRuns;

public class CreatePayrollRunDto
{
    public string RunNumber { get; set; } = string.Empty;
    public int Month { get; set; }
    public int Year { get; set; }
    public DateTime ProcessDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; }
}

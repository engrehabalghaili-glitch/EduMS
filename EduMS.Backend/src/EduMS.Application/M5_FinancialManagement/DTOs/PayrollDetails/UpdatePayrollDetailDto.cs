using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.PayrollDetails;

public class UpdatePayrollDetailDto
{
    public long Id { get; set; }
    public long PayrollRunId { get; set; }
    public long EmployeeId { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal TotalAllowances { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetSalary { get; set; }
    public int Status { get; set; }
}

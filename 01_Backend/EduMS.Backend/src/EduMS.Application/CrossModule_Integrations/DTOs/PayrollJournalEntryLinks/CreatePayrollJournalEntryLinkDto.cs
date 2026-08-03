using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.PayrollJournalEntryLinks;

public class CreatePayrollJournalEntryLinkDto
{
    public long PayrollDetailId { get; set; }
    public long JournalEntryId { get; set; }
    public long EmployeeId { get; set; }
    public long PayrollRunId { get; set; }
    public decimal SalaryAmount { get; set; }
    public string? Notes { get; set; }
}

using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyFinancialExpenseLinks;

public class CreateEmergencyFinancialExpenseLinkDto
{
    public long SchoolId { get; set; }
    public long? EmergencyIncidentId { get; set; }
    public long? EmergencyHostingId { get; set; }
    public long? EmergencyClosureId { get; set; }
    public long JournalEntryId { get; set; }
    public decimal ExpenseAmount { get; set; }
    public string ExpenseCategory { get; set; } = string.Empty;
    public string? Notes { get; set; }
}

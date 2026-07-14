using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.JournalEntryLines;

public class UpdateJournalEntryLineDto
{
    public long Id { get; set; }
    public long JournalEntryId { get; set; }
    public long AccountId { get; set; }
    public decimal DebitAmount { get; set; }
    public decimal CreditAmount { get; set; }
    public string Description { get; set; } = string.Empty;
}

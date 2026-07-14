using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.JournalEntries;

public class CreateJournalEntryDto
{
    public long SchoolId { get; set; }
    public string EntryNumber { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; }
}

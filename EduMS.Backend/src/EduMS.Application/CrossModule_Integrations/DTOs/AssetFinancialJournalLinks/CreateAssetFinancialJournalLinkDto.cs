using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.AssetFinancialJournalLinks;

public class CreateAssetFinancialJournalLinkDto
{
    public long SchoolAssetId { get; set; }
    public long JournalEntryId { get; set; }
    public long SchoolId { get; set; }
    public string EntryType { get; set; } = string.Empty;
    public decimal EntryAmount { get; set; }
    public DateTime EntryDate { get; set; }
    public string? Notes { get; set; }
}

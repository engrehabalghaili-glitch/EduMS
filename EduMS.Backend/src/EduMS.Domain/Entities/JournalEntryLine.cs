using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class JournalEntryLine : BaseEntity
{
    public long JournalEntryId { get; set; }
    public long AccountId { get; set; }
    public decimal DebitAmount { get; set; }
    public decimal CreditAmount { get; set; }
    public string Description { get; set; } = string.Empty;

    // Navigation Properties
    public JournalEntry? JournalEntry { get; set; }
    public Account? Account { get; set; }
}

using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class JournalEntry : BaseAuditableEntity
{
    public string EntryNumber { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; } // 0=Draft, 1=Posted
    
    // Navigation Property
    public ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
}

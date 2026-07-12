using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class JournalEntry : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string EntryNumber { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; } // 0=Draft, 1=Posted
    
    // Cross-Module and Collection Navigation Properties
    public virtual School? School { get; set; }
    public virtual ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
}

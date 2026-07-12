using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class PayrollRun : BaseAuditableEntity
{
    public string RunNumber { get; set; } = string.Empty; // e.g. "PR_2026_07"
    public int Month { get; set; }
    public int Year { get; set; }
    public DateTime ProcessDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; } // 0=Draft, 1=Approved, 2=Disbursed
    
    // Navigation Property
    public virtual ICollection<PayrollDetail> PayrollDetails { get; set; } = new List<PayrollDetail>();
}

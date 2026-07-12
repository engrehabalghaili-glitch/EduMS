using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class FeeStructure : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string FeeCode { get; set; } = string.Empty;
    public string FeeNameAr { get; set; } = string.Empty;
    public string FeeNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public decimal Amount { get; set; }
    public string AcademicYear { get; set; } = string.Empty;

    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual ICollection<FeeInvoice> Invoices { get; set; } = new List<FeeInvoice>();
}

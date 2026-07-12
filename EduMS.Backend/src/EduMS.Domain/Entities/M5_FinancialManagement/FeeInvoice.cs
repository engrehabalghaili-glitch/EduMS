using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class FeeInvoice : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long FeeStructureId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime DueDate { get; set; }
    public int Status { get; set; } // 1=Unpaid, 2=PartiallyPaid, 3=Paid

    // Cross-Module Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual FeeStructure? FeeStructure { get; set; }
}

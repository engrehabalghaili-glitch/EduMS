using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class PaymentVoucher : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? VendorId { get; set; } // Nullable if paying general expense/payroll
    public string VoucherNumber { get; set; } = string.Empty;
    public DateTime VoucherDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // Cash, Bank, Check
    public string Description { get; set; } = string.Empty;
    
    // Links to accounting
    public long? AccountId { get; set; } // Cash/Bank AccountId (FK -> Account)
    
    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual Vendor? Vendor { get; set; }
    public virtual Account? Account { get; set; }
}

using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class PaymentVoucher : BaseAuditableEntity
{
    public string VoucherNumber { get; set; } = string.Empty;
    public DateTime VoucherDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // Cash, Bank, Check
    public string Description { get; set; } = string.Empty;
    
    // Links to accounting
    public long? AccountId { get; set; } // Cash/Bank AccountId (FK -> Account)
    
    // Navigation Property
    public Account? Account { get; set; }
}

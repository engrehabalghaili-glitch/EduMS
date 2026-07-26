using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Vendor : BaseAuditableEntity
{
    public string VendorName { get; set; } = string.Empty;
    public string? TaxNumber { get; set; } // VAT tracking
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual ICollection<PaymentVoucher> PaymentVouchers { get; set; } = new List<PaymentVoucher>();
}

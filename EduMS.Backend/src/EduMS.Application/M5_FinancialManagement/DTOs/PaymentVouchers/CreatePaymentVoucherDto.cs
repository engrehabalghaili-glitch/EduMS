using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.PaymentVouchers;

public class CreatePaymentVoucherDto
{
    public long SchoolId { get; set; }
    public long? VendorId { get; set; }
    public string VoucherNumber { get; set; } = string.Empty;
    public DateTime VoucherDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long? AccountId { get; set; }
}

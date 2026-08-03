using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.PaymentToInvoiceSettlements;

public class CreatePaymentToInvoiceSettlementDto
{
    public long PaymentVoucherId { get; set; }
    public long FeeInvoiceId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public decimal AllocatedAmount { get; set; }
    public string? Notes { get; set; }
}

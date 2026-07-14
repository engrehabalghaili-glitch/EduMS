using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.AssetProcurementPaymentLinks;

public class UpdateAssetProcurementPaymentLinkDto
{
    public long Id { get; set; }
    public long PurchaseOrderId { get; set; }
    public long PaymentVoucherId { get; set; }
    public long SchoolId { get; set; }
    public decimal PaidAmount { get; set; }
    public string? Notes { get; set; }
}

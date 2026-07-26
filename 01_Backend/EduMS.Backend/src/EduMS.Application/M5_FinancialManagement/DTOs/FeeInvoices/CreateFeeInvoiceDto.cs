using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeInvoices;

public class CreateFeeInvoiceDto
{
    public long StudentId { get; set; }
    public long FeeStructureId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime DueDate { get; set; }
    public int Status { get; set; }
}

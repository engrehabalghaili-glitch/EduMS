using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.Vendors;

public class CreateVendorDto
{
    public string VendorName { get; set; } = string.Empty;
    public string? TaxNumber { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public bool IsActive { get; set; } = true;
}

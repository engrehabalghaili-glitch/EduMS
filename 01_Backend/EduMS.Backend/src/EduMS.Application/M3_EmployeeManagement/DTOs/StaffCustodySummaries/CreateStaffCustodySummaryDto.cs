using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;

public class CreateStaffCustodySummaryDto
{
    public long EmployeeId { get; set; }
    public string? CustodySummaryJson { get; set; }
    public decimal TotalItemsCount { get; set; }
    public decimal TotalEstimatedValue { get; set; }
    public DateTime? CustodyIssuedDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public int CustodyStatus { get; set; } = 1;
    public DateTime? ClearanceDate { get; set; }
    public long? ClearedByUserId { get; set; }
    public string? ClearanceNotes { get; set; }
    public string? ClearanceDocumentUrl { get; set; }
    public string? Notes { get; set; }
}

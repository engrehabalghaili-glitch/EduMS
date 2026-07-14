using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInternalTransfers;

public class UpdateEmployeeInternalTransferDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string TransferRequestNumber { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public long FromDepartmentId { get; set; }
    public long ToDepartmentId { get; set; }
    public string? FromJobTitle { get; set; }
    public string? ToJobTitle { get; set; }
    public string TransferReason { get; set; } = string.Empty;
    public DateTime? EffectiveDate { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public string? Notes { get; set; }
}

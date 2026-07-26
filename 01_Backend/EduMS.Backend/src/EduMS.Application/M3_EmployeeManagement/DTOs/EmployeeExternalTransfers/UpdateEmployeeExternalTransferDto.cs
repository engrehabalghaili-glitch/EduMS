using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;

public class UpdateEmployeeExternalTransferDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? FromSchoolId { get; set; }
    public long? ToSchoolId { get; set; }
    public long? FromDirectorateId { get; set; }
    public long? ToDirectorateId { get; set; }
    public long? FromOrganizationalSectorId { get; set; }
    public long? ToOrganizationalSectorId { get; set; }
    public string TransferRequestNumber { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public int TransferDirection { get; set; }
    public string TransferReason { get; set; } = string.Empty;
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? MinistryDecisionNumber { get; set; }
    public DateTime? MinistryDecisionDate { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }
}

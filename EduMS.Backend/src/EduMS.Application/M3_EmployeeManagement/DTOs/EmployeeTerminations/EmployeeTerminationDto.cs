using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTerminations;

public class EmployeeTerminationDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string TerminationReferenceNumber { get; set; } = string.Empty;
    public DateTime TerminationDate { get; set; }
    public int TerminationType { get; set; }
    public string TerminationReason { get; set; } = string.Empty;
    public DateTime? LastWorkingDay { get; set; }
    public bool CustodyCleared { get; set; }
    public DateTime? CustodyClearanceDate { get; set; }
    public bool FinancialCleared { get; set; }
    public DateTime? FinancialClearanceDate { get; set; }
    public decimal GratuityAmount { get; set; }
    public decimal FinalSalarySettlement { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int TerminationStatus { get; set; } = 1;
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}

using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;

public class StudentExemptionDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public int ExemptionCategory { get; set; }
    public decimal DiscountPercentage { get; set; }
    public string? ReasonDescription { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ExemptionCode { get; set; }
    public string? SupportingDocumentUrl { get; set; }
    public decimal AnnualMaxDiscountAmount { get; set; }
    public bool IsRenewable { get; set; }
    public bool IsActive { get; set; }

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

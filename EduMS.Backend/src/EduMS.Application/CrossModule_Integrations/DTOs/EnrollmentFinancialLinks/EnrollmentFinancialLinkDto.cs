using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EnrollmentFinancialLinks;

public class EnrollmentFinancialLinkDto
{
    public long Id { get; set; }
    public long EnrollmentId { get; set; }
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public decimal TuitionFeeDue { get; set; }
    public decimal DiscountApplied { get; set; }
    public decimal ExemptionApplied { get; set; }
    public decimal NetPayable { get; set; }
    public bool IsSettled { get; set; }
    public DateTime? SettlementDate { get; set; }
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

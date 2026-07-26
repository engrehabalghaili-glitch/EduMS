using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;

public class SchoolOperationalBudgetLogDto
{
    public long Id { get; set; }
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public string BudgetCategoryCode { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal ConsumedAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public int Status { get; set; }
    public string? CategoryNameEn { get; set; }
    public int QuarterNumber { get; set; }
    public long? ApprovedByDirectorId { get; set; }
    public DateTime? LastTransactionDate { get; set; }
    public string? NotesDescription { get; set; }

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

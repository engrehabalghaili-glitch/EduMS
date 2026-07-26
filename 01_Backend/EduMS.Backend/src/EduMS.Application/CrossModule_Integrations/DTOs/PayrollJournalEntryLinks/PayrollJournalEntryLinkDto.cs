using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.PayrollJournalEntryLinks;

public class PayrollJournalEntryLinkDto
{
    public long Id { get; set; }
    public long PayrollDetailId { get; set; }
    public long JournalEntryId { get; set; }
    public long EmployeeId { get; set; }
    public long PayrollRunId { get; set; }
    public decimal SalaryAmount { get; set; }
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

using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;

public class FeeStructureDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string FeeCode { get; set; } = string.Empty;
    public string FeeNameAr { get; set; } = string.Empty;
    public string FeeNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public decimal Amount { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
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

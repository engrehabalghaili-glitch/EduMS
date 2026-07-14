using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.ReportSnapshotSourceLinks;

public class ReportSnapshotSourceLinkDto
{
    public long Id { get; set; }
    public long StatisticalReportSnapshotId { get; set; }
    public long SchoolId { get; set; }
    public string SourceModule { get; set; } = string.Empty;
    public string SourceEntityType { get; set; } = string.Empty;
    public long? SourceEntityId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string? AggregationDescription { get; set; }
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

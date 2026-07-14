using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.ReportSnapshotSourceLinks;

public class CreateReportSnapshotSourceLinkDto
{
    public long StatisticalReportSnapshotId { get; set; }
    public long SchoolId { get; set; }
    public string SourceModule { get; set; } = string.Empty;
    public string SourceEntityType { get; set; } = string.Empty;
    public long? SourceEntityId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string? AggregationDescription { get; set; }
    public string? Notes { get; set; }
}

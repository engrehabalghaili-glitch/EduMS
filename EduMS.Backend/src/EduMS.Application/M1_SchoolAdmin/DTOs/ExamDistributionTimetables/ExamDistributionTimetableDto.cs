using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;

public class ExamDistributionTimetableDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public long? FacilityId { get; set; }
    public long? ProctorEmployeeId { get; set; }
    public DateTime ExamDate { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public int MaxSeatCount { get; set; }
    public int Status { get; set; }
    public string? ExamSessionNameAr { get; set; }
    public int ExamType { get; set; }
    public int TermSemesterNumber { get; set; }
    public long? AssistantProctorEmployeeId { get; set; }
    public bool IsSeatingChartPublished { get; set; }

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

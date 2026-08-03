using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.ClassSections;

public class ClassSectionDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? ClassroomId { get; set; }
    public string SectionCode { get; set; } = string.Empty;
    public string SectionNameAr { get; set; } = string.Empty;
    public string? SectionNameEn { get; set; }
    public int MaxStudents { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public long? ShiftId { get; set; }
    public int SectionStatus { get; set; }
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

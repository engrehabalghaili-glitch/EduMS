using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;

public class StudentEnrollmentDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int EnrollmentStatus { get; set; }
    public bool IsCurrentTerm { get; set; }
    public int EnrollmentType { get; set; }
    public int AssignedRollNumber { get; set; }
    public int PromotionStatus { get; set; }
    public string? EnrollmentRemarks { get; set; }

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

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;

public class ClassroomDto
{
    // Base Entity
    public long Id { get; set; }

    // Classroom Properties
    public long SchoolId { get; set; }
    public string ClassroomCode { get; set; } = string.Empty;
    public string ClassroomNameAr { get; set; } = string.Empty;
    public string ClassroomNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public int Capacity { get; set; }
    public string? RoomNumber { get; set; }
    public int FloorLevel { get; set; }
    public string? BuildingSection { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public bool IsSmartClassroom { get; set; }
    public bool IsActive { get; set; }

    // Auditing Fields (From BaseAuditableEntity)
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    
    // Enum Representation as String
    public string SyncStatus { get; set; } = string.Empty;
}

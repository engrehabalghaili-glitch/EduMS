using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;

public class SubjectDto
{
    // Base Entity
    public long Id { get; set; }

    // Subject Properties
    public long SchoolId { get; set; }
    public string SubjectCode { get; set; } = string.Empty;
    public string SubjectNameAr { get; set; } = string.Empty;
    public string SubjectNameEn { get; set; } = string.Empty;
    public string? Specialization { get; set; }
    public int WeeklyHours { get; set; }
    public int GradeLevel { get; set; }
    public string? TextbookTitle { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal PassingMarks { get; set; }
    public decimal CreditHours { get; set; }
    public bool IsCoreSubject { get; set; }
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

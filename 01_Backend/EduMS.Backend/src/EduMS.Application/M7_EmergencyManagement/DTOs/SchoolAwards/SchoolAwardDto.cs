using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SchoolAwards;

public class SchoolAwardDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string AwardNumber { get; set; } = string.Empty;
    public string AwardName { get; set; } = string.Empty;
    public string? AwardCategory { get; set; }
    public int AwardLevel { get; set; }
    public string? IssuingBody { get; set; }
    public string? IssuingBodyType { get; set; }
    public DateTime AwardDate { get; set; }
    public string? AwardPlace { get; set; }
    public string? Ranking { get; set; }
    public string? ParticipantsJson { get; set; }
    public int StudentParticipantsCount { get; set; }
    public int TeacherParticipantsCount { get; set; }
    public string? AwardDetails { get; set; }
    public string? CertificatePath { get; set; }
    public string? PhotosPathJson { get; set; }
    public string? VideoPath { get; set; }
    public string? Impact { get; set; }
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

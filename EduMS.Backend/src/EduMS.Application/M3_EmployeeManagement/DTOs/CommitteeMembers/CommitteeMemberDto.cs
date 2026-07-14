using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;

public class CommitteeMemberDto
{
    public long Id { get; set; }
    public long CommitteeId { get; set; }
    public long EmployeeId { get; set; }
    public int MemberRole { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public bool IsActive { get; set; } = true;
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

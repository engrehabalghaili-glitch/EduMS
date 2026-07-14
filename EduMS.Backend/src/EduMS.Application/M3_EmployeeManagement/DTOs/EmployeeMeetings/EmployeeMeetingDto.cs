using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;

public class EmployeeMeetingDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? CommitteeId { get; set; }
    public string MeetingTitleAr { get; set; } = string.Empty;
    public DateTime MeetingDateTime { get; set; }
    public string MeetingLocation { get; set; } = string.Empty;
    public int MeetingType { get; set; }
    public string? AgendaJson { get; set; }
    public string? MinutesText { get; set; }
    public string? DecisionsJson { get; set; }
    public int MeetingStatus { get; set; } = 1;
    public long? ChairmanEmployeeId { get; set; }
    public string? AttachmentsJson { get; set; }
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

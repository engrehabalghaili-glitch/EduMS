using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeCommittees;

public class EmployeeCommitteeDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string CommitteeNameAr { get; set; } = string.Empty;
    public string? CommitteeNameEn { get; set; }
    public string CommitteeCode { get; set; } = string.Empty;
    public int CommitteeType { get; set; }
    public DateTime FormationDate { get; set; }
    public DateTime? DissolutionDate { get; set; }
    public string? Objectives { get; set; }
    public long? ChairmanEmployeeId { get; set; }
    public int CommitteeStatus { get; set; } = 1;
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

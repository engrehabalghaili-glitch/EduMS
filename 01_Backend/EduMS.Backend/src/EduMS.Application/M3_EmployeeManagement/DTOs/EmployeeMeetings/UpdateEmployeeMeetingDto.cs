using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;

public class UpdateEmployeeMeetingDto
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
}

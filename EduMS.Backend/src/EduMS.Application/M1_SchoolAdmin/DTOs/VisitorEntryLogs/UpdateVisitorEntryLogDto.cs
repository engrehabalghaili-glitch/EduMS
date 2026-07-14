using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.VisitorEntryLogs;

public class UpdateVisitorEntryLogDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string VisitorFullName { get; set; } = string.Empty;
    public string NationalIdOrPassport { get; set; } = string.Empty;
    public string VisitPurpose { get; set; } = string.Empty;
    public long? HostEmployeeId { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public string? VisitorBadgeNumber { get; set; }
    public int Status { get; set; }
    public string? VisitorPhoneNumber { get; set; }
    public string? VisitorOrganization { get; set; }
    public string? SecurityGateNumber { get; set; }
    public long? SecurityOfficerEmployeeId { get; set; }
}

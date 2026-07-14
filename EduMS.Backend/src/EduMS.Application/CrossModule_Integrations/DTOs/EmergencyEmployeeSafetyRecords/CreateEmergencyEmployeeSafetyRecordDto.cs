using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyEmployeeSafetyRecords;

public class CreateEmergencyEmployeeSafetyRecordDto
{
    public long EmergencyIncidentId { get; set; }
    public long EmployeeId { get; set; }
    public long SchoolId { get; set; }
    public int SafetyStatus { get; set; } = 1;
    public bool IsOnDutyDuringIncident { get; set; }
    public string? AssignedRole { get; set; }
    public string? Notes { get; set; }
}

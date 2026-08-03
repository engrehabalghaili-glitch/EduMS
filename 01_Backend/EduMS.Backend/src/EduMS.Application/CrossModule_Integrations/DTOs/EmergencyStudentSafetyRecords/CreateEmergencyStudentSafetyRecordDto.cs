using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyStudentSafetyRecords;

public class CreateEmergencyStudentSafetyRecordDto
{
    public long EmergencyIncidentId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public int SafetyStatus { get; set; } = 1;
    public bool ParentNotified { get; set; }
    public DateTime? ParentNotificationTime { get; set; }
    public string? Location { get; set; }
    public string? Notes { get; set; }
}

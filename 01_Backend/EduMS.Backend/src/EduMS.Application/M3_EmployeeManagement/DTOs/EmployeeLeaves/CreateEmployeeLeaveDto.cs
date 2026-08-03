using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeLeaves;

public class CreateEmployeeLeaveDto
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDays { get; set; }
    public string LeaveReason { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public bool IsEmergency { get; set; }
    public string? ReplacementEmployeeName { get; set; }
    public string? Notes { get; set; }
}

using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;

public class CreateCommitteeMemberDto
{
    public long CommitteeId { get; set; }
    public long EmployeeId { get; set; }
    public int MemberRole { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

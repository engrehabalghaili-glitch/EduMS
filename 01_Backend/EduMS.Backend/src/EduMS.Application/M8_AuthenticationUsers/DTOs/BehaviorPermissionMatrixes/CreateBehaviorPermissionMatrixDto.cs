using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;

public class CreateBehaviorPermissionMatrixDto
{
    public long SchoolId { get; set; }
    public long RoleId { get; set; }
    public string BehaviorLevel { get; set; } = string.Empty;
    public bool CanRecord { get; set; }
    public bool CanInvestigate { get; set; }
    public bool CanDecidePenalty { get; set; }
    public bool CanExecutePenalty { get; set; }
    public bool CanWaivePenalty { get; set; }
    public bool RequiresCommitteeDecision { get; set; }
    public string? Notes { get; set; }
}

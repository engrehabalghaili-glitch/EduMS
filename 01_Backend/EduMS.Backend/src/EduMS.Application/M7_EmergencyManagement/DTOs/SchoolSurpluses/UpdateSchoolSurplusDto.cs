using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SchoolSurpluses;

public class UpdateSchoolSurplusDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string SurplusNumber { get; set; } = string.Empty;
    public string SurplusType { get; set; } = string.Empty;
    public string? SurplusCategory { get; set; }
    public decimal SurplusAmount { get; set; }
    public decimal AvailableAmount { get; set; }
    public decimal RequiredAmount { get; set; }
    public string? SurplusDescription { get; set; }
    public string? UtilizationPlan { get; set; }
    public string? UtilizationType { get; set; }
    public string? PotentialBeneficiary { get; set; }
    public DateTime DiscoveryDate { get; set; }
    public long? DiscoveredByUserId { get; set; }
    public int SurplusStatus { get; set; } = 1;
    public DateTime? StatusUpdateDate { get; set; }
    public DateTime? UtilizationDate { get; set; }
    public DateTime? ActualUtilizationDate { get; set; }
    public long? UtilizedByUserId { get; set; }
    public string? UtilizationNotes { get; set; }
    public long? RelatedRemediationPlanId { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }
}

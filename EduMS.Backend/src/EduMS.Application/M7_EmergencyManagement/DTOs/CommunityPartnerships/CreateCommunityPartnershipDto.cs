using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.CommunityPartnerships;

public class CreateCommunityPartnershipDto
{
    public long SchoolId { get; set; }
    public string PartnershipNumber { get; set; } = string.Empty;
    public string PartnerName { get; set; } = string.Empty;
    public string? PartnerType { get; set; }
    public string? SupportType { get; set; }
    public DateTime? AgreementDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsRenewable { get; set; }
    public string? AgreementDocumentPath { get; set; }
    public decimal SupportValueAmount { get; set; }
    public string? SupportValueCurrency { get; set; }
    public string? SupportInKindJson { get; set; }
    public string? Impact { get; set; }
    public int ImpactRating { get; set; }
    public long? ResponsibleEmployeeId { get; set; }
    public string? PartnerContactPerson { get; set; }
    public string? PartnerContactEmail { get; set; }
    public string? PartnerContactPhone { get; set; }
    public int PartnershipStatus { get; set; } = 1;
    public string? Notes { get; set; }
}

using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;

public class UpdateOfficialCircularDto
{
    public long Id { get; set; }
    public string CircularNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public int CircularType { get; set; }
    public string IssuerName { get; set; } = string.Empty;
    public int TargetAudience { get; set; }
    public DateTime EffectiveDate { get; set; }
    public bool IsActive { get; set; }
    public string? ContentBody { get; set; }
    public long? IssuerEmployeeId { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public bool RequiresMandatoryAcknowledgment { get; set; }
    public DateTime? AcknowledgmentDeadline { get; set; }
}

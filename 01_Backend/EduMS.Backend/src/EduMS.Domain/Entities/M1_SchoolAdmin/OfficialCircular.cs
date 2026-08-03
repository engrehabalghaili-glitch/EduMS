using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class OfficialCircular : BaseAuditableEntity
{
    public string CircularNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public int CircularType { get; set; } // 1=Educational, 2=Financial, 3=Administrative
    public string IssuerName { get; set; } = string.Empty;
    public int TargetAudience { get; set; } // 1=AllSchools, 2=SpecificSchools, 3=Teachers
    public DateTime EffectiveDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ContentBody { get; set; }
    public long? IssuerEmployeeId { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public bool RequiresMandatoryAcknowledgment { get; set; }
    public DateTime? AcknowledgmentDeadline { get; set; }

    // Navigation Property
    public virtual Employee? IssuerEmployee { get; set; }
}

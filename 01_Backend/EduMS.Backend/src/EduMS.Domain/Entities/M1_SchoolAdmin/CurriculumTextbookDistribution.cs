using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class CurriculumTextbookDistribution : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public string TextbookCode { get; set; } = string.Empty;
    public string TextbookTitleAr { get; set; } = string.Empty;
    public string TextbookTitleEn { get; set; } = string.Empty;
    public int EditionYear { get; set; }
    public int QuantityAllocated { get; set; }
    public int QuantityDistributed { get; set; }
    public DateTime DistributionDate { get; set; } = DateTime.UtcNow;
    public int TargetGradeLevel { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalValueAmount { get; set; }
    public string? WarehouseLocationCode { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Subject? Subject { get; set; }
}

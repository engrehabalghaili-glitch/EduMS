using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.CurriculumTextbookDistributions;

public class UpdateCurriculumTextbookDistributionDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public string TextbookCode { get; set; } = string.Empty;
    public string TextbookTitleAr { get; set; } = string.Empty;
    public string TextbookTitleEn { get; set; } = string.Empty;
    public int EditionYear { get; set; }
    public int QuantityAllocated { get; set; }
    public int QuantityDistributed { get; set; }
    public DateTime DistributionDate { get; set; }
    public int TargetGradeLevel { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalValueAmount { get; set; }
    public string? WarehouseLocationCode { get; set; }
    public bool IsActive { get; set; }
}

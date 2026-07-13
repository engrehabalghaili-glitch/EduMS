using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.CurriculumTextbookDistributions;

public class CreateCurriculumTextbookDistributionDto
{
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public string TextbookCode { get; set; }
    public string TextbookTitleAr { get; set; }
    public string TextbookTitleEn { get; set; }
    public int EditionYear { get; set; }
    public int QuantityAllocated { get; set; }
    public int QuantityDistributed { get; set; }
    public DateTime DistributionDate { get; set; }
    public int TargetGradeLevel { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalValueAmount { get; set; }
    public string? WarehouseLocationCode { get; set; }
}

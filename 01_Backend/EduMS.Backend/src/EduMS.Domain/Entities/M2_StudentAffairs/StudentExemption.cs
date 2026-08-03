using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentExemption : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public int ExemptionCategory { get; set; } // 1=TuitionDiscount, 2=SubjectExemption, 3=TransportationExemption
    public decimal DiscountPercentage { get; set; }
    public string? ReasonDescription { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ExemptionCode { get; set; }
    public string? SupportingDocumentUrl { get; set; }
    public decimal AnnualMaxDiscountAmount { get; set; }
    public bool IsRenewable { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Employee? ApprovedByEmployee { get; set; }
}

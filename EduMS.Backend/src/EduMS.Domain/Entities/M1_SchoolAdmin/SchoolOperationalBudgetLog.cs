using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolOperationalBudgetLog : BaseAuditableEntity
{
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public string BudgetCategoryCode { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
    public decimal AllocatedAmount { get; set; }
    public decimal ConsumedAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public int Status { get; set; } // 1=Allocated, 2=InUse, 3=Exhausted, 4=Closed
    public string? CategoryNameEn { get; set; }
    public int QuarterNumber { get; set; } = 1;
    public long? ApprovedByDirectorId { get; set; }
    public DateTime? LastTransactionDate { get; set; }
    public string? NotesDescription { get; set; }

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
    public virtual School? School { get; set; }
}

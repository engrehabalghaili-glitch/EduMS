using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class PayrollDetail : BaseAuditableEntity
{
    public long PayrollRunId { get; set; }
    public long EmployeeId { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal TotalAllowances { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetSalary { get; set; }
    public int Status { get; set; } // 0=Pending, 1=Paid

    // Navigation Properties
    public virtual PayrollRun? PayrollRun { get; set; }
    public virtual Employee? Employee { get; set; }
}

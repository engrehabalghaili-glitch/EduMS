using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeePayrollFinancialContractRepository : IGenericRepository<EmployeePayrollFinancialContract>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب العقود المالية بناءً على حالة الصرف المالي (معلق، مخصص، مصروف، مرفوض)
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractsByDisbursementStatusAsync(int disbursementStatus, CancellationToken cancellationToken = default);
    
    // جلب العقود الخاصة بمركز تكلفة معين (Cost Center)
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractsByCostCenterAsync(string costCenterCode, CancellationToken cancellationToken = default);
    
    // جلب العقود المالية خلال فترة زمنية محددة
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب العقود المالية التابعة لموظف محدد
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب العقود المرتبطة بكشف راتب محدد
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractByPayrollIdAsync(long employeePayrollId, CancellationToken cancellationToken = default);
    
    // جلب العقود التي قام بمراجعتها مراجع مالي محدد
    Task<IEnumerable<EmployeePayrollFinancialContract>> GetContractsAuditedByEmployeeAsync(long auditorEmployeeId, CancellationToken cancellationToken = default);
}

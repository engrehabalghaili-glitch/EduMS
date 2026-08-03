using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IPayrollDetailRepository : IGenericRepository<PayrollDetail>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تفاصيل الرواتب بناءً على حالة الدفع (معلق، مدفوع)
    Task<IEnumerable<PayrollDetail>> GetDetailsByStatusAsync(int status, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تفاصيل رواتب مسير معين (PayrollRun)
    Task<IEnumerable<PayrollDetail>> GetDetailsByPayrollRunIdAsync(long payrollRunId, CancellationToken cancellationToken = default);
    
    // جلب السجل المالي لرواتب موظف محدد
    Task<IEnumerable<PayrollDetail>> GetDetailsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
}

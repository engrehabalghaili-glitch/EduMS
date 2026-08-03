using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IPayrollRunRepository : IGenericRepository<PayrollRun>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب مسيرات الرواتب بناءً على الحالة (مسودة، معتمد، مصروف)
    Task<IEnumerable<PayrollRun>> GetRunsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب مسير الرواتب لشهر وسنة محددين
    Task<PayrollRun?> GetRunByMonthAndYearAsync(int month, int year, CancellationToken cancellationToken = default);
}

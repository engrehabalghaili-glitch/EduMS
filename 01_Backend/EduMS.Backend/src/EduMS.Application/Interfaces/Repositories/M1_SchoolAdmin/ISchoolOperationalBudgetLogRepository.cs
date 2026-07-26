using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolOperationalBudgetLogRepository : IGenericRepository<SchoolOperationalBudgetLog>
{
    // 1. Specific Filtering
    // جلب الميزانية لمدرسة معينة في سنة مالية محددة
    Task<IEnumerable<SchoolOperationalBudgetLog>> GetBudgetLogsByFiscalYearAsync(long schoolId, string fiscalYear, CancellationToken cancellationToken = default);
    
    // جلب البند المالي حسب الكود
    Task<SchoolOperationalBudgetLog?> GetBudgetLogByCodeAsync(long schoolId, string fiscalYear, string budgetCategoryCode, CancellationToken cancellationToken = default);
    
    // 2. Status Filters
    // جلب البنود المالية حسب الحالة (مخصص، مستخدم، مستنفد، مغلق)
    Task<IEnumerable<SchoolOperationalBudgetLog>> GetBudgetLogsByStatusAsync(long schoolId, string fiscalYear, int status, CancellationToken cancellationToken = default);
    
    // 3. Analytics Helper
    // جلب البنود التي اقتربت من النفاد (حيث المبلغ المتبقي أقل من حد معين)
    Task<IEnumerable<SchoolOperationalBudgetLog>> GetLowBalanceBudgetLogsAsync(long schoolId, string fiscalYear, decimal threshold, CancellationToken cancellationToken = default);
}




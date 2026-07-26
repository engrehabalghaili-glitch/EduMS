using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IStaffCustodySummaryRepository : IGenericRepository<StaffCustodySummary>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب ملخصات العهدة بناءً على حالتها (نشطة، مصفاة، قيد التصفية)
    Task<IEnumerable<StaffCustodySummary>> GetSummariesByStatusAsync(int custodyStatus, CancellationToken cancellationToken = default);
    
    // جلب الملخصات التي لم تتم تصفيتها بعد
    Task<IEnumerable<StaffCustodySummary>> GetPendingClearanceSummariesAsync(CancellationToken cancellationToken = default);
    
    // جلب الملخصات التي تتجاوز قيمة عهدتها حد معين
    Task<IEnumerable<StaffCustodySummary>> GetSummariesByMinimumValueAsync(decimal minimumValue, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب ملخص العهدة الخاص بموظف محدد
    Task<IEnumerable<StaffCustodySummary>> GetSummaryByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب ملخصات العهدة التي قام بتصفيتها موظف/مستخدم محدد
    Task<IEnumerable<StaffCustodySummary>> GetSummariesClearedByUserAsync(long clearedByUserId, CancellationToken cancellationToken = default);
}

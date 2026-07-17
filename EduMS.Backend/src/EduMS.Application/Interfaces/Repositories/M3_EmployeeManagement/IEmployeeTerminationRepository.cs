using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeTerminationRepository : IGenericRepository<EmployeeTermination>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب قرارات إنهاء الخدمة بناءً على حالة الإجراء (مبدئي، قيد التصفية، مكتمل)
    Task<IEnumerable<EmployeeTermination>> GetTerminationsByStatusAsync(int terminationStatus, CancellationToken cancellationToken = default);
    
    // جلب القرارات بناءً على نوع إنهاء الخدمة (استقالة، تقاعد، فصل، الخ)
    Task<IEnumerable<EmployeeTermination>> GetTerminationsByTypeAsync(int terminationType, CancellationToken cancellationToken = default);
    
    // جلب الإجراءات التي لم تكتمل تصفية العهد فيها بعد
    Task<IEnumerable<EmployeeTermination>> GetTerminationsPendingCustodyClearanceAsync(CancellationToken cancellationToken = default);
    
    // جلب الإجراءات التي لم تكتمل التصفية المالية فيها بعد
    Task<IEnumerable<EmployeeTermination>> GetTerminationsPendingFinancialClearanceAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب إجراء إنهاء الخدمة الخاص بموظف محدد
    Task<IEnumerable<EmployeeTermination>> GetTerminationByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب قرارات إنهاء الخدمة في مدرسة معينة
    Task<IEnumerable<EmployeeTermination>> GetTerminationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

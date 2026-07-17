using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface ISelfServicePortalRequestRepository : IGenericRepository<SelfServicePortalRequest>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الطلبات بناءً على حالتها (مقدم، قيد المراجعة، معتمد، مرفوض)
    Task<IEnumerable<SelfServicePortalRequest>> GetRequestsByStatusAsync(int requestStatus, CancellationToken cancellationToken = default);
    
    // جلب الطلبات بناءً على نوعها (طلب إجازة، طلب وثيقة، طلب تحديث بيانات)
    Task<IEnumerable<SelfServicePortalRequest>> GetRequestsByTypeAsync(int requestType, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي تم تقديمها خلال فترة محددة
    Task<IEnumerable<SelfServicePortalRequest>> GetRequestsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة طلبات الخدمة الذاتية التي قدمها موظف محدد
    Task<IEnumerable<SelfServicePortalRequest>> GetRequestsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي قام مستخدم/مدير معين بمراجعتها
    Task<IEnumerable<SelfServicePortalRequest>> GetRequestsReviewedByUserAsync(long reviewedByUserId, CancellationToken cancellationToken = default);
}

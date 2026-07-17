using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IBehaviorPermissionRecordRepository : IGenericRepository<BehaviorPermissionRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات صلاحيات السلوك الفعالة
    Task<IEnumerable<BehaviorPermissionRecord>> GetActiveRecordsAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات الصلاحيات الحساسة
    Task<IEnumerable<BehaviorPermissionRecord>> GetSensitiveRecordsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب السجلات الخاصة بمدرسة محددة
    Task<IEnumerable<BehaviorPermissionRecord>> GetRecordsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب السجلات المرتبطة بدور محدد
    Task<IEnumerable<BehaviorPermissionRecord>> GetRecordsByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
}

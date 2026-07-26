using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IBehaviorPermissionRepository : IGenericRepository<BehaviorPermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب صلاحيات التوجيه والإرشاد الفعالة
    Task<IEnumerable<BehaviorPermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات التي تتطلب دور الأخصائي الاجتماعي
    Task<IEnumerable<BehaviorPermission>> GetPermissionsRequiringSocialWorkerAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب صلاحيات التوجيه المرتبطة بمدرسة محددة
    Task<IEnumerable<BehaviorPermission>> GetPermissionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IBehaviorPermissionMatrixRepository : IGenericRepository<BehaviorPermissionMatrix>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب صلاحيات السلوك المرتبطة بمستوى معين (الدرجة الأولى، الثانية، الخ)
    Task<IEnumerable<BehaviorPermissionMatrix>> GetMatrixByBehaviorLevelAsync(string behaviorLevel, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب مصفوفة صلاحيات السلوك الخاصة بدور محدد
    Task<IEnumerable<BehaviorPermissionMatrix>> GetMatrixByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
    
    // جلب مصفوفة الصلاحيات الخاصة بمدرسة محددة
    Task<IEnumerable<BehaviorPermissionMatrix>> GetMatrixBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

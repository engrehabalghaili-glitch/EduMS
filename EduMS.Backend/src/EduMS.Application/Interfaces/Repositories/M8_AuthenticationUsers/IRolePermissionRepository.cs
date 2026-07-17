using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الصلاحيات الفعالة للأدوار
    Task<IEnumerable<RolePermission>> GetActiveRolePermissionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الصلاحيات الممنوحة لدور محدد
    Task<IEnumerable<RolePermission>> GetPermissionsByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
    
    // جلب الأدوار التي تملك صلاحية محددة
    Task<IEnumerable<RolePermission>> GetRolesByPermissionIdAsync(long permissionId, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IUserDirectPermissionRepository : IGenericRepository<UserDirectPermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الصلاحيات المباشرة الفعالة
    Task<IEnumerable<UserDirectPermission>> GetActiveDirectPermissionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الصلاحيات المباشرة الممنوحة لمستخدم محدد
    Task<IEnumerable<UserDirectPermission>> GetPermissionsByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    
    // جلب المستخدمين الذين مُنحوا صلاحية مباشرة محددة
    Task<IEnumerable<UserDirectPermission>> GetUsersByPermissionIdAsync(long permissionId, CancellationToken cancellationToken = default);
}

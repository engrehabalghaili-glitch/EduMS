using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface ISystemPermissionRepository : IGenericRepository<SystemPermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الصلاحيات الفعالة
    Task<IEnumerable<SystemPermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات بناءً على الوحدة (Module) مثل شئون الطلاب، المالية، الخ
    Task<IEnumerable<SystemPermission>> GetPermissionsByModuleAsync(string module, CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات الحساسة (IsSensitive = true)
    Task<IEnumerable<SystemPermission>> GetSensitivePermissionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهوية
    // جلب صلاحية معينة باستخدام مفتاح الصلاحية (PermissionKey)
    Task<SystemPermission?> GetPermissionByKeyAsync(string permissionKey, CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات التابعة لنوع صلاحية محدد (PermissionTypeId)
    Task<IEnumerable<SystemPermission>> GetPermissionsByTypeIdAsync(long permissionTypeId, CancellationToken cancellationToken = default);
}

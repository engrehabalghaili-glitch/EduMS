using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IPermissionTypeRepository : IGenericRepository<PermissionType>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أنواع الصلاحيات الفعالة
    Task<IEnumerable<PermissionType>> GetActivePermissionTypesAsync(CancellationToken cancellationToken = default);
    
    // جلب أنواع الصلاحيات بناءً على تصنيفها (عرض، إنشاء، تعديل، حذف، اعتماد)
    Task<IEnumerable<PermissionType>> GetPermissionTypesByCategoryAsync(string category, CancellationToken cancellationToken = default);
    
    // جلب أنواع الصلاحيات التي تتطلب اعتماد
    Task<IEnumerable<PermissionType>> GetPermissionTypesRequiringApprovalAsync(CancellationToken cancellationToken = default);

    // 2. التحقق (Validation)
    // التحقق من عدم تكرار كود النوع (TypeCode)
    Task<bool> IsTypeCodeUniqueAsync(string typeCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IPermissionBaseModuleRepository : IGenericRepository<PermissionBaseModule>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الوحدات الأساسية للصلاحيات الفعالة
    Task<IEnumerable<PermissionBaseModule>> GetActiveModulesAsync(CancellationToken cancellationToken = default);

    // 2. التحقق (Validation)
    // التحقق من عدم تكرار كود الوحدة الأساسية (ModuleCode)
    Task<bool> IsModuleCodeUniqueAsync(string moduleCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

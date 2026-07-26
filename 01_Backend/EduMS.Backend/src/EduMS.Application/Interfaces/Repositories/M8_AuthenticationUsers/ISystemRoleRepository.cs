using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface ISystemRoleRepository : IGenericRepository<SystemRole>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأدوار الفعالة في النظام
    Task<IEnumerable<SystemRole>> GetActiveRolesAsync(CancellationToken cancellationToken = default);
    
    // جلب الأدوار بناءً على نوع الدور (نظام، مدرسة، مكتب، مؤقت)
    Task<IEnumerable<SystemRole>> GetRolesByTypeAsync(int roleType, CancellationToken cancellationToken = default);
    
    // جلب الأدوار الأساسية (System Roles)
    Task<IEnumerable<SystemRole>> GetSystemRolesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهرمية (Hierarchy)
    // جلب دور بناءً على كود الدور (RoleCode)
    Task<SystemRole?> GetRoleByCodeAsync(string roleCode, CancellationToken cancellationToken = default);
    
    // جلب الأدوار الفرعية لدور محدد (ParentRoleId)
    Task<IEnumerable<SystemRole>> GetChildRolesAsync(long parentRoleId, CancellationToken cancellationToken = default);
}

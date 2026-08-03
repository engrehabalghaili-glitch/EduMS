using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IRoleMatrixRepository : IGenericRepository<RoleMatrix>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب مصفوفة الأدوار الفعالة
    Task<IEnumerable<RoleMatrix>> GetActiveRoleMatricesAsync(CancellationToken cancellationToken = default);
    
    // جلب المصفوفات بناءً على نوع الدور
    Task<IEnumerable<RoleMatrix>> GetRoleMatricesByTypeAsync(int roleType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهوية (Foreign Keys and Identity)
    // جلب مصفوفة الأدوار الخاصة بمدرسة محددة
    Task<IEnumerable<RoleMatrix>> GetRoleMatricesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب مصفوفة الأدوار المتعلقة بكود دور محدد (RoleCode)
    Task<RoleMatrix?> GetRoleMatrixByRoleCodeAsync(string roleCode, CancellationToken cancellationToken = default);
}

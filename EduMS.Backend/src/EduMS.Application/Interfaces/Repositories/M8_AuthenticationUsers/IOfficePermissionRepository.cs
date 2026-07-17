using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IOfficePermissionRepository : IGenericRepository<OfficePermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب صلاحيات مكتب التعليم الفعالة
    Task<IEnumerable<OfficePermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات التي تسمح بتخطي أو تجاوز قرارات المدرسة
    Task<IEnumerable<OfficePermission>> GetOverridePermissionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب صلاحيات مكتب تعليم محدد
    Task<IEnumerable<OfficePermission>> GetPermissionsByOfficeIdAsync(long officeId, CancellationToken cancellationToken = default);
}

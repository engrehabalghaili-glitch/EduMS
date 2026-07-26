using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IStudentFinancePermissionRepository : IGenericRepository<StudentFinancePermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الصلاحيات المالية للطلاب الفعالة
    Task<IEnumerable<StudentFinancePermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات المالية التي تتطلب موافقة الإدارة أو مجلس الإدارة
    Task<IEnumerable<StudentFinancePermission>> GetPermissionsRequiringHigherApprovalAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الصلاحيات المالية الخاصة بمدرسة محددة
    Task<IEnumerable<StudentFinancePermission>> GetPermissionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

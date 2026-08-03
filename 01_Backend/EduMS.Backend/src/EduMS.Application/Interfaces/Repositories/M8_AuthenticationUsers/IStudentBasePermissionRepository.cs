using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IStudentBasePermissionRepository : IGenericRepository<StudentBasePermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب صلاحيات شؤون الطلاب الأساسية الفعالة
    Task<IEnumerable<StudentBasePermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات التي تتطلب موافقة مدير المدرسة
    Task<IEnumerable<StudentBasePermission>> GetPermissionsRequiringPrincipalApprovalAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الصلاحيات الخاصة بمدرسة محددة
    Task<IEnumerable<StudentBasePermission>> GetPermissionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

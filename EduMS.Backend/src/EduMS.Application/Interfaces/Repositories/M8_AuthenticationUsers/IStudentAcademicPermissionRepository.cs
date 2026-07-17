using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IStudentAcademicPermissionRepository : IGenericRepository<StudentAcademicPermission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الصلاحيات الأكاديمية الفعالة
    Task<IEnumerable<StudentAcademicPermission>> GetActivePermissionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الصلاحيات المرتبطة بفترة زمنية محددة (IsTimeBound = true)
    Task<IEnumerable<StudentAcademicPermission>> GetTimeBoundPermissionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الصلاحيات الأكاديمية الخاصة بمدرسة محددة
    Task<IEnumerable<StudentAcademicPermission>> GetPermissionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

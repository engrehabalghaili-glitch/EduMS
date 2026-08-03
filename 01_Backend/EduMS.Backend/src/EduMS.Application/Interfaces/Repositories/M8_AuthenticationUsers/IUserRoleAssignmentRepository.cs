using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IUserRoleAssignmentRepository : IGenericRepository<UserRoleAssignment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تعيينات الأدوار الفعالة
    Task<IEnumerable<UserRoleAssignment>> GetActiveAssignmentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الأدوار المسندة لمستخدم محدد
    Task<IEnumerable<UserRoleAssignment>> GetAssignmentsByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    
    // جلب جميع المستخدمين المسند لهم دور محدد
    Task<IEnumerable<UserRoleAssignment>> GetAssignmentsByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
    
    // جلب تعيينات الأدوار الخاصة بمدرسة محددة
    Task<IEnumerable<UserRoleAssignment>> GetAssignmentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

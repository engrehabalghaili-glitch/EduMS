using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IUserEmployeeIdentityLinkRepository : IGenericRepository<UserEmployeeIdentityLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط الفعالة (التي تربط بين مستخدم وموظف بشكل صحيح)
    Task<IEnumerable<UserEmployeeIdentityLink>> GetActiveLinksAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب بيانات ربط موظف محدد
    Task<UserEmployeeIdentityLink?> GetLinkByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب بيانات ربط مستخدم محدد (بموظف)
    Task<UserEmployeeIdentityLink?> GetLinkBySystemUserIdAsync(long systemUserId, CancellationToken cancellationToken = default);
    
    // جلب روابط موظفي مدرسة محددة
    Task<IEnumerable<UserEmployeeIdentityLink>> GetLinksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

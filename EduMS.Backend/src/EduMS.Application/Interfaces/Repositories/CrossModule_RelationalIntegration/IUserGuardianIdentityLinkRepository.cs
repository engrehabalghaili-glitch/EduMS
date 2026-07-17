using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IUserGuardianIdentityLinkRepository : IGenericRepository<UserGuardianIdentityLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط الفعالة لأولياء الأمور
    Task<IEnumerable<UserGuardianIdentityLink>> GetActiveLinksAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب بيانات ربط ولي أمر محدد بطالب معين
    Task<IEnumerable<UserGuardianIdentityLink>> GetLinksByStudentGuardianRelationshipIdAsync(long studentGuardianRelationshipId, CancellationToken cancellationToken = default);
    
    // جلب جميع الطلاب المرتبطين بحساب ولي الأمر
    Task<IEnumerable<UserGuardianIdentityLink>> GetLinksBySystemUserIdAsync(long systemUserId, CancellationToken cancellationToken = default);
    
    // جلب أولياء الأمور المرتبطين بطالب محدد
    Task<IEnumerable<UserGuardianIdentityLink>> GetLinksByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}

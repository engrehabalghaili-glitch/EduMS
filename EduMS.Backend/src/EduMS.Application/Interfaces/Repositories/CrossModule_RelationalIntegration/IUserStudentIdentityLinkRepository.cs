using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IUserStudentIdentityLinkRepository : IGenericRepository<UserStudentIdentityLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط الفعالة للطلاب
    Task<IEnumerable<UserStudentIdentityLink>> GetActiveLinksAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب بيانات ربط طالب محدد
    Task<UserStudentIdentityLink?> GetLinkByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب بيانات ربط مستخدم محدد (بطالب)
    Task<UserStudentIdentityLink?> GetLinkBySystemUserIdAsync(long systemUserId, CancellationToken cancellationToken = default);
    
    // جلب روابط طلاب مدرسة محددة
    Task<IEnumerable<UserStudentIdentityLink>> GetLinksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEnrollmentFinancialLinkRepository : IGenericRepository<EnrollmentFinancialLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط التي لم تتم تسويتها بعد (الذمم المفتوحة)
    Task<IEnumerable<EnrollmentFinancialLink>> GetUnsettledLinksAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الروابط المالية لتسجيل أكاديمي محدد
    Task<IEnumerable<EnrollmentFinancialLink>> GetLinksByEnrollmentIdAsync(long enrollmentId, CancellationToken cancellationToken = default);
    
    // جلب الروابط المتعلقة بحساب طالب محدد (المالية)
    Task<IEnumerable<EnrollmentFinancialLink>> GetLinksByStudentAccountIdAsync(long studentAccountId, CancellationToken cancellationToken = default);
    
    // جلب الروابط الخاصة بطالب معين (تجميعية)
    Task<IEnumerable<EnrollmentFinancialLink>> GetLinksByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}

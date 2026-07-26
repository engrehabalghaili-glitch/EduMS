using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IUsageViolationRepository : IGenericRepository<UsageViolation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المخالفات بناءً على حالتها (مسجلة، قيد التحقيق، تم اتخاذ إجراء، مغلقة)
    Task<IEnumerable<UsageViolation>> GetViolationsByStatusAsync(string status, CancellationToken cancellationToken = default);
    
    // جلب المخالفات التي ترتب عليها غرامة مالية (استقطاع من الراتب أو غيره)
    Task<IEnumerable<UsageViolation>> GetViolationsWithPenaltiesAsync(CancellationToken cancellationToken = default);
    
    // جلب المخالفات بناءً على نوع المخالفة (سوء استخدام، إهمال، الخ)
    Task<IEnumerable<UsageViolation>> GetViolationsByTypeAsync(string violationType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المخالفات المرتبطة بأصل محدد
    Task<IEnumerable<UsageViolation>> GetViolationsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب المخالفات الخاصة بمدرسة محددة
    Task<IEnumerable<UsageViolation>> GetViolationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المخالفات التي تم تسجيلها على مستخدم محدد
    Task<IEnumerable<UsageViolation>> GetViolationsByViolatingUserAsync(long violatingUserId, CancellationToken cancellationToken = default);
}

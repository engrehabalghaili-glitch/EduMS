using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetFeasibilityComparisonRepository : IGenericRepository<AssetFeasibilityComparison>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المقارنات التي تنتظر اتخاذ قرار
    Task<IEnumerable<AssetFeasibilityComparison>> GetComparisonsAwaitingDecisionAsync(CancellationToken cancellationToken = default);
    
    // جلب المقارنات بناءً على التوصية (إصلاح، استبدال، الخ)
    Task<IEnumerable<AssetFeasibilityComparison>> GetComparisonsByRecommendationAsync(int recommendation, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب مقارنات الجدوى الخاصة بأصل محدد
    Task<IEnumerable<AssetFeasibilityComparison>> GetComparisonsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب جميع دراسات الجدوى للأصول في مدرسة محددة
    Task<IEnumerable<AssetFeasibilityComparison>> GetComparisonsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

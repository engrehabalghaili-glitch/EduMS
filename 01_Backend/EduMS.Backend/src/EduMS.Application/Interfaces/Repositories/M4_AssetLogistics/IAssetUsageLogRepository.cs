using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetUsageLogRepository : IGenericRepository<AssetUsageLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الاستخدامات النشطة حالياً للأصول
    Task<IEnumerable<AssetUsageLog>> GetActiveUsagesAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات الاستخدام في فترة زمنية محددة
    Task<IEnumerable<AssetUsageLog>> GetUsagesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات استخدام أصل محدد
    Task<IEnumerable<AssetUsageLog>> GetUsagesByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب سجلات الاستخدام لمستخدم محدد
    Task<IEnumerable<AssetUsageLog>> GetUsagesByUserAsync(long usedByUserId, CancellationToken cancellationToken = default);
    
    // جلب سجلات الاستخدام الخاصة بمدرسة معينة
    Task<IEnumerable<AssetUsageLog>> GetUsagesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetMovementHistoryRepository : IGenericRepository<AssetMovementHistory>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب حركات الأصول بناءً على نوع الحركة (نقل، إعارة، صيانة، إتلاف، الخ)
    Task<IEnumerable<AssetMovementHistory>> GetMovementHistoryByActionTypeAsync(string actionType, CancellationToken cancellationToken = default);
    
    // جلب الحركات التي تمت في فترة زمنية محددة
    Task<IEnumerable<AssetMovementHistory>> GetMovementHistoryByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب السجل التاريخي لحركة أصل محدد
    Task<IEnumerable<AssetMovementHistory>> GetMovementHistoryByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب حركات الأصول في مدرسة معينة
    Task<IEnumerable<AssetMovementHistory>> GetMovementHistoryBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الحركات التي قام بها مستخدم محدد
    Task<IEnumerable<AssetMovementHistory>> GetMovementHistoryPerformedByUserAsync(long performedByUserId, CancellationToken cancellationToken = default);
}

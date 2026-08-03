using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetInspectionLogRepository : IGenericRepository<AssetInspectionLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الفحص بناءً على النتيجة (مقبول، مرفوض، يحتاج صيانة، يحتاج استبدال)
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsByResultAsync(int inspectionResult, CancellationToken cancellationToken = default);
    
    // جلب سجلات الفحص بناءً على نوع الفحص (عند الاستلام، عند الإرجاع، دوري)
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsByTypeAsync(int inspectionType, CancellationToken cancellationToken = default);
    
    // جلب سجلات الفحص التي تمت في فترة زمنية معينة
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع سجلات الفحص لأصل محدد
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب سجلات الفحص الخاصة بمدرسة معينة
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الفحوصات التي قام بها مستخدم/فاحص محدد
    Task<IEnumerable<AssetInspectionLog>> GetInspectionLogsByInspectorAsync(long inspectorUserId, CancellationToken cancellationToken = default);
}

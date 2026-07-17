using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IPreventiveMaintenanceScheduleRepository : IGenericRepository<PreventiveMaintenanceSchedule>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب جداول الصيانة الوقائية الفعالة
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetActiveSchedulesAsync(CancellationToken cancellationToken = default);
    
    // جلب مهام الصيانة الوقائية التي حان موعدها أو اقترب
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetDueSchedulesAsync(DateTime targetDate, CancellationToken cancellationToken = default);
    
    // جلب جداول الصيانة بناءً على نوع الصيانة (تنظيف، فحص، استبدال قطع، الخ)
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetSchedulesByTypeAsync(int maintenanceType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جداول الصيانة لأصل محدد
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetSchedulesByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب الجداول الخاصة بفئة أصول محددة
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetSchedulesByAssetCategoryIdAsync(long assetCategoryId, CancellationToken cancellationToken = default);
    
    // جلب الجداول الخاصة بمدرسة معينة
    Task<IEnumerable<PreventiveMaintenanceSchedule>> GetSchedulesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

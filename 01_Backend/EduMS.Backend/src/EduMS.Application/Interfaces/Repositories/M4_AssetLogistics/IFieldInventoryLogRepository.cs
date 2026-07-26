using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IFieldInventoryLogRepository : IGenericRepository<FieldInventoryLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب السجلات التي تم فيها تحديد حالة الأصل كـ "مفقود" (غير موجود)
    Task<IEnumerable<FieldInventoryLog>> GetMissingAssetsLogsAsync(CancellationToken cancellationToken = default);
    
    // جلب السجلات بناءً على حالة الأصل الفعلية التي رصدت في الميدان (جيد، تالف، يحتاج صيانة)
    Task<IEnumerable<FieldInventoryLog>> GetLogsByActualConditionAsync(int actualCondition, CancellationToken cancellationToken = default);
    
    // جلب السجلات غير المعتمدة (التي لم يتم التحقق منها بعد)
    Task<IEnumerable<FieldInventoryLog>> GetUnverifiedLogsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات المسح الميداني لخطة جرد محددة
    Task<IEnumerable<FieldInventoryLog>> GetLogsByInventoryPlanIdAsync(long inventoryPlanId, CancellationToken cancellationToken = default);
    
    // جلب السجلات التي قام بها مستخدم/ماسح ضوئي محدد
    Task<IEnumerable<FieldInventoryLog>> GetLogsByScannerUserAsync(long scannerUserId, CancellationToken cancellationToken = default);
    
    // جلب السجلات المتعلقة بأصل محدد
    Task<IEnumerable<FieldInventoryLog>> GetLogsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IInventoryReconciliationRepository : IGenericRepository<InventoryReconciliation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الفروقات المفتوحة (التي لم يتم حلها بعد)
    Task<IEnumerable<InventoryReconciliation>> GetUnresolvedDiscrepanciesAsync(CancellationToken cancellationToken = default);
    
    // جلب الفروقات بناءً على حالة المطابقة (مفتوح، قيد التحقيق، محلول)
    Task<IEnumerable<InventoryReconciliation>> GetReconciliationsByStatusAsync(int reconciliationStatus, CancellationToken cancellationToken = default);
    
    // جلب الفروقات بناءً على نوع الاختلاف (مفقود، فائض، تالف، الخ)
    Task<IEnumerable<InventoryReconciliation>> GetReconciliationsByDiscrepancyTypeAsync(int discrepancyType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المطابقات المتعلقة بخطة جرد محددة
    Task<IEnumerable<InventoryReconciliation>> GetReconciliationsByInventoryPlanIdAsync(long inventoryPlanId, CancellationToken cancellationToken = default);
    
    // جلب المطابقات الخاصة بمدرسة معينة
    Task<IEnumerable<InventoryReconciliation>> GetReconciliationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المطابقات المرتبطة بأصل محدد
    Task<IEnumerable<InventoryReconciliation>> GetReconciliationsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
}

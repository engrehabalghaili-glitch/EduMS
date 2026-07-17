using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetReceivingRepository : IGenericRepository<AssetReceiving>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الاستلامات التي تنتظر الفحص (Under Inspection)
    Task<IEnumerable<AssetReceiving>> GetReceivingsPendingInspectionAsync(CancellationToken cancellationToken = default);
    
    // جلب الاستلامات بناءً على نتيجة الفحص (مطابق، غير مطابق، الخ)
    Task<IEnumerable<AssetReceiving>> GetReceivingsByInspectionResultAsync(int inspectionResult, CancellationToken cancellationToken = default);
    
    // جلب الاستلامات التي يوجد طلب إرجاع لها
    Task<IEnumerable<AssetReceiving>> GetReceivingsWithReturnRequestsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب استلامات مدرسة محددة
    Task<IEnumerable<AssetReceiving>> GetReceivingsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الاستلامات المرتبطة بأمر شراء محدد
    Task<IEnumerable<AssetReceiving>> GetReceivingsByPurchaseOrderIdAsync(long purchaseOrderId, CancellationToken cancellationToken = default);
}

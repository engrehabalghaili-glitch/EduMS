using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المستودعات الفعالة
    Task<IEnumerable<Warehouse>> GetActiveWarehousesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المستودعات التابعة لمالك محدد (جهة أو مدرسة)
    Task<IEnumerable<Warehouse>> GetWarehousesByOwnerAsync(string ownerType, long ownerId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار اسم المستودع (اختياري حسب الحاجة)
    Task<bool> IsWarehouseNameUniqueAsync(string warehouseName, long? excludeId = null, CancellationToken cancellationToken = default);
}

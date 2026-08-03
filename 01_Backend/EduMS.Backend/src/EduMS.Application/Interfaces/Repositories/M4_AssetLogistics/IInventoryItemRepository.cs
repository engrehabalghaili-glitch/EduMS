using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IInventoryItemRepository : IGenericRepository<InventoryItem>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأصناف التي نفذت كمياتها (Quantity = 0)
    Task<IEnumerable<InventoryItem>> GetOutOfStockItemsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الأصناف المتوفرة في مستودع محدد
    Task<IEnumerable<InventoryItem>> GetItemsByWarehouseIdAsync(long warehouseId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار كود الصنف
    Task<bool> IsItemCodeUniqueAsync(string itemCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

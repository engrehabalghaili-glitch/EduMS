using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolCanteenItemRepository : IGenericRepository<SchoolCanteenItem>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود الصنف أو الباركود
    Task<bool> IsItemCodeUniqueAsync(long schoolId, string itemCode, long? excludeId = null);
    Task<bool> IsBarcodeUniqueAsync(long schoolId, string barcodeNumber, long? excludeId = null);
    
    // 2. Status Filters
    // جلب الأصناف المتاحة للبيع
    Task<IEnumerable<SchoolCanteenItem>> GetAvailableItemsAsync(long schoolId);
    
    // جلب الأصناف المعتمدة صحياً
    Task<IEnumerable<SchoolCanteenItem>> GetHealthApprovedItemsAsync(long schoolId);
    
    // 3. Inventory Helpers
    // جلب الأصناف التي وصل مخزونها لحد إعادة الطلب (Reorder Threshold)
    Task<IEnumerable<SchoolCanteenItem>> GetLowStockItemsAsync(long schoolId);
    
    // 4. Filtering by category
    // جلب الأصناف بناءً على تصنيفها الغذائي
    Task<IEnumerable<SchoolCanteenItem>> GetItemsByNutritionalCategoryAsync(long schoolId, int category);
}


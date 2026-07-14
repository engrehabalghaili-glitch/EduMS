using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolLibraryItemRepository : IGenericRepository<SchoolLibraryItem>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود الكتاب/العنصر أو رقم الـ ISBN
    Task<bool> IsItemCodeUniqueAsync(long schoolId, string itemCode, long? excludeId = null);
    Task<bool> IsIsbnUniqueAsync(long schoolId, string isbn, long? excludeId = null);
    
    // 2. Status Filters
    // جلب العناصر المتاحة للاستعارة (Available)
    Task<IEnumerable<SchoolLibraryItem>> GetAvailableItemsAsync(long schoolId);
    
    // 3. Search and Filtering
    // البحث بالاسم (عربي أو إنجليزي) أو اسم المؤلف
    Task<IEnumerable<SchoolLibraryItem>> SearchLibraryItemsAsync(long schoolId, string searchTerm);
    
    // جلب العناصر حسب التصنيف (أدب، علوم، دوريات، الخ)
    Task<IEnumerable<SchoolLibraryItem>> GetItemsByCategoryAsync(long schoolId, int category);
}


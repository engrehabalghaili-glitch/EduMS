using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetCategoryRepository : IGenericRepository<AssetCategory>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الفئات الفعالة
    Task<IEnumerable<AssetCategory>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default);
    
    // جلب الفئات الأساسية (التي ليس لها فئة أب)
    Task<IEnumerable<AssetCategory>> GetRootCategoriesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهيكلية (Foreign Keys and Hierarchy)
    // جلب الفئات الفرعية التابعة لفئة معينة
    Task<IEnumerable<AssetCategory>> GetSubCategoriesAsync(long parentCategoryId, CancellationToken cancellationToken = default);
    
    // جلب فئات الأصول الخاصة بمدرسة محددة
    Task<IEnumerable<AssetCategory>> GetCategoriesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الفئة
    Task<bool> IsCategoryCodeUniqueAsync(string categoryCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

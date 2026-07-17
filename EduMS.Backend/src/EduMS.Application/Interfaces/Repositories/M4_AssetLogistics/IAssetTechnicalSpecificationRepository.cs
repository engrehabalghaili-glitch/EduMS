using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetTechnicalSpecificationRepository : IGenericRepository<AssetTechnicalSpecification>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المواصفات الفنية الفعالة حالياً
    Task<IEnumerable<AssetTechnicalSpecification>> GetActiveSpecificationsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المواصفات الفنية الخاصة بمدرسة محددة
    Task<IEnumerable<AssetTechnicalSpecification>> GetSpecificationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المواصفات الخاصة بفئة أصول محددة
    Task<IEnumerable<AssetTechnicalSpecification>> GetSpecificationsByAssetCategoryIdAsync(long assetCategoryId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار كود المواصفة
    Task<bool> IsSpecCodeUniqueAsync(string specCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

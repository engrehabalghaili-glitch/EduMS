using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface ISchoolAssetRepository : IGenericRepository<SchoolAsset>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأصول الفعالة في النظام
    Task<IEnumerable<SchoolAsset>> GetActiveAssetsAsync(CancellationToken cancellationToken = default);
    
    // جلب الأصول بناءً على حالتها (جديد، جيد، تالف، يحتاج صيانة، الخ)
    Task<IEnumerable<SchoolAsset>> GetAssetsByConditionAsync(int condition, CancellationToken cancellationToken = default);
    
    // جلب الأصول التي تتطلب التأمين أو لها تأمين ساري
    Task<IEnumerable<SchoolAsset>> GetInsuredAssetsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الأصول التابعة لمدرسة محددة
    Task<IEnumerable<SchoolAsset>> GetAssetsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الأصول التابعة لفئة معينة
    Task<IEnumerable<SchoolAsset>> GetAssetsByCategoryIdAsync(long assetCategoryId, CancellationToken cancellationToken = default);
    
    // جلب الأصول الموجودة في موقع محدد
    Task<IEnumerable<SchoolAsset>> GetAssetsByLocationIdAsync(long assetLocationId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الأصل
    Task<bool> IsAssetCodeUniqueAsync(string assetCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

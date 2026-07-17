using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetDepreciationRepository : IGenericRepository<AssetDepreciation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سياسات الإهلاك للأصول المهلكة بالكامل (التي انتهت قيمتها الدفترية)
    Task<IEnumerable<AssetDepreciation>> GetFullyDepreciatedAssetsAsync(CancellationToken cancellationToken = default);
    
    // جلب سياسات الإهلاك بناءً على نوع طريقة الإهلاك المستخدمة
    Task<IEnumerable<AssetDepreciation>> GetDepreciationsByMethodAsync(int methodType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سياسة الإهلاك الخاصة بأصل محدد
    Task<IEnumerable<AssetDepreciation>> GetDepreciationsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب سياسات الإهلاك لجميع أصول مدرسة محددة
    Task<IEnumerable<AssetDepreciation>> GetDepreciationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

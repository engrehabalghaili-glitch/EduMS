using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetRevaluationImpairmentRepository : IGenericRepository<AssetRevaluationImpairment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب عمليات التقييم بناءً على حالتها (مسودة، معتمد، مرحل)
    Task<IEnumerable<AssetRevaluationImpairment>> GetOperationsByStatusAsync(int operationStatus, CancellationToken cancellationToken = default);
    
    // جلب العمليات بناءً على نوعها (إعادة تقييم، أو انخفاض قيمة)
    Task<IEnumerable<AssetRevaluationImpairment>> GetOperationsByTypeAsync(int operationType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب عمليات التقييم لأصل محدد
    Task<IEnumerable<AssetRevaluationImpairment>> GetOperationsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب عمليات التقييم المرتبطة بمدرسة محددة
    Task<IEnumerable<AssetRevaluationImpairment>> GetOperationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

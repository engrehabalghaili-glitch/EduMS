using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetStatusRecordRepository : IGenericRepository<AssetStatusRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحالات الفعالة في النظام
    Task<IEnumerable<AssetStatusRecord>> GetActiveStatusesAsync(CancellationToken cancellationToken = default);
    
    // جلب الحالات التشغيلية (مثل: يعمل، متاح)
    Task<IEnumerable<AssetStatusRecord>> GetOperationalStatusesAsync(CancellationToken cancellationToken = default);
    
    // جلب الحالات التي تتطلب موافقة مسبقة للدخول فيها
    Task<IEnumerable<AssetStatusRecord>> GetStatusesRequiringApprovalAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الحالات الخاصة بمدرسة محددة (إن وجدت)
    Task<IEnumerable<AssetStatusRecord>> GetStatusesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الحالة
    Task<bool> IsStatusCodeUniqueAsync(string statusCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

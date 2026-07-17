using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetSuspensionRequestRepository : IGenericRepository<AssetSuspensionRequest>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات التعليق بناءً على حالة الموافقة (تحت المراجعة، معتمد، مرفوض)
    Task<IEnumerable<AssetSuspensionRequest>> GetRequestsByApprovalStatusAsync(string approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات التعليق بناءً على حالة الطلب نفسه (نشط، منتهي، ملغى)
    Task<IEnumerable<AssetSuspensionRequest>> GetRequestsByStatusAsync(string status, CancellationToken cancellationToken = default);
    
    // جلب طلبات التعليق التي تم إبطالها (Revoked)
    Task<IEnumerable<AssetSuspensionRequest>> GetRevokedRequestsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات التعليق المرتبطة بأصل محدد
    Task<IEnumerable<AssetSuspensionRequest>> GetRequestsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب طلبات التعليق في مدرسة محددة
    Task<IEnumerable<AssetSuspensionRequest>> GetRequestsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

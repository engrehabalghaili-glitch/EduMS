using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetTransferRequestRepository : IGenericRepository<AssetTransferRequest>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات النقل بناءً على حالة الموافقة (قيد المراجعة، معتمد، مرفوض)
    Task<IEnumerable<AssetTransferRequest>> GetTransferRequestsByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل بناءً على حالة الطلب (مفتوح، معتمد، منفذ)
    Task<IEnumerable<AssetTransferRequest>> GetTransferRequestsByStatusAsync(int requestStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل حسب النوع (مكاني، إداري، بين المدارس)
    Task<IEnumerable<AssetTransferRequest>> GetTransferRequestsByTypeAsync(int transferType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات نقل أصل محدد
    Task<IEnumerable<AssetTransferRequest>> GetTransferRequestsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الخاصة بمدرسة محددة
    Task<IEnumerable<AssetTransferRequest>> GetTransferRequestsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

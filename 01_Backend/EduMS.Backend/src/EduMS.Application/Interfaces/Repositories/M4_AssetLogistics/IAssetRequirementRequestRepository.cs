using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetRequirementRequestRepository : IGenericRepository<AssetRequirementRequest>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات الاحتياج بناءً على حالتها (مسودة، تحت المراجعة، معتمد، مرفوض، الخ)
    Task<IEnumerable<AssetRequirementRequest>> GetRequestsByStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب الطلبات ذات الأولوية العالية والطارئة
    Task<IEnumerable<AssetRequirementRequest>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي تم تحويلها إلى أوامر شراء
    Task<IEnumerable<AssetRequirementRequest>> GetConvertedToPurchaseOrderRequestsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات الاحتياج لمدرسة محددة
    Task<IEnumerable<AssetRequirementRequest>> GetRequestsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات الصادرة من قسم معين
    Task<IEnumerable<AssetRequirementRequest>> GetRequestsByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات المرفوعة من قبل موظف محدد
    Task<IEnumerable<AssetRequirementRequest>> GetRequestsByEmployeeAsync(long requestedByEmployeeId, CancellationToken cancellationToken = default);
}

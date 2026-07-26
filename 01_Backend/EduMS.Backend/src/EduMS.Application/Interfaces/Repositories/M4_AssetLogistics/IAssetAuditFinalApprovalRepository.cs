using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetAuditFinalApprovalRepository : IGenericRepository<AssetAuditFinalApproval>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الاعتمادات النهائية بناءً على نوع الاعتماد (جرد سنوي، تدقيق داخلي، الخ)
    Task<IEnumerable<AssetAuditFinalApproval>> GetApprovalsByTypeAsync(int approvalType, CancellationToken cancellationToken = default);
    
    // جلب الاعتمادات التي لم يتم تحديث حالتها في النظام بعد
    Task<IEnumerable<AssetAuditFinalApproval>> GetPendingSystemUpdateApprovalsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الاعتمادات النهائية الخاصة بمدرسة محددة
    Task<IEnumerable<AssetAuditFinalApproval>> GetApprovalsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الاعتماد النهائي المرتبط بخطة جرد محددة
    Task<AssetAuditFinalApproval?> GetApprovalByInventoryPlanIdAsync(long inventoryPlanId, CancellationToken cancellationToken = default);
    
    // جلب الاعتماد النهائي المرتبط بجلسة تدقيق محددة
    Task<AssetAuditFinalApproval?> GetApprovalByComplianceAuditIdAsync(long complianceAuditId, CancellationToken cancellationToken = default);
}

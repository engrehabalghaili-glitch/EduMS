using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetComplianceAuditRepository : IGenericRepository<AssetComplianceAudit>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب جلسات التدقيق بناءً على حالة التدقيق (مجدول، قيد التنفيذ، مكتمل)
    Task<IEnumerable<AssetComplianceAudit>> GetAuditsByStatusAsync(int auditStatus, CancellationToken cancellationToken = default);
    
    // جلب التدقيقات بناءً على النوع (داخلي، خارجي، دوري)
    Task<IEnumerable<AssetComplianceAudit>> GetAuditsByTypeAsync(int auditType, CancellationToken cancellationToken = default);
    
    // جلب جلسات التدقيق التي تقل درجة الامتثال فيها عن حد معين
    Task<IEnumerable<AssetComplianceAudit>> GetAuditsByMinimumScoreAsync(decimal minComplianceScore, CancellationToken cancellationToken = default);
    
    // جلب التدقيقات التي تتطلب إجراءات تصحيحية متأخرة
    Task<IEnumerable<AssetComplianceAudit>> GetAuditsWithOverdueCorrectiveActionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جلسات التدقيق الخاصة بمدرسة محددة
    Task<IEnumerable<AssetComplianceAudit>> GetAuditsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

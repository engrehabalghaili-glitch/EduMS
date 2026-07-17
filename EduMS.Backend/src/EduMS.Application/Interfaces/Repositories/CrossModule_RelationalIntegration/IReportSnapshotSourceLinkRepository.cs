using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IReportSnapshotSourceLinkRepository : IGenericRepository<ReportSnapshotSourceLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب مصادر البيانات التي بُني عليها تقرير إحصائي (لقطة) محدد
    Task<IEnumerable<ReportSnapshotSourceLink>> GetLinksBySnapshotIdAsync(long statisticalReportSnapshotId, CancellationToken cancellationToken = default);
    
    // جلب التقارير التي تم استخدام كيان محدد في بنائها
    Task<IEnumerable<ReportSnapshotSourceLink>> GetLinksBySourceEntityAsync(string sourceModule, string sourceEntityType, long? sourceEntityId, CancellationToken cancellationToken = default);
    
    // جلب مصادر التقارير لمدرسة محددة
    Task<IEnumerable<ReportSnapshotSourceLink>> GetLinksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

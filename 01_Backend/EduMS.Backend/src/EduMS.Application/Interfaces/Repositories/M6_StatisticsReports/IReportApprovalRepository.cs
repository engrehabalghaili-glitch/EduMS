using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IReportApprovalRepository : IGenericRepository<ReportApproval>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الاعتمادات بناءً على حالة الاعتماد (بانتظار المراجعة، معتمد، مرفوض)
    Task<IEnumerable<ReportApproval>> GetApprovalsByStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب الاعتمادات النهائية (IsFinal = true)
    Task<IEnumerable<ReportApproval>> GetFinalApprovalsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الاعتمادات المتعلقة بتقرير نظام محدد
    Task<IEnumerable<ReportApproval>> GetApprovalsBySystemReportIdAsync(long systemReportId, CancellationToken cancellationToken = default);
    
    // جلب الاعتمادات الخاصة بمدرسة محددة
    Task<IEnumerable<ReportApproval>> GetApprovalsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

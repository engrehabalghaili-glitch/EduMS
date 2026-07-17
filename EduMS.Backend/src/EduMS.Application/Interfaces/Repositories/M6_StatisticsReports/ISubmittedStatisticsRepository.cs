using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface ISubmittedStatisticsRepository : IGenericRepository<SubmittedStatistics>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإحصائيات المرفوعة بناءً على حالة الاعتماد (تحت المراجعة، مقبول، مرفوض، الخ)
    Task<IEnumerable<SubmittedStatistics>> GetSubmittedStatisticsByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب الإحصائيات التي تعتبر نهائية ومغلقة
    Task<IEnumerable<SubmittedStatistics>> GetFinalStatisticsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الإحصائيات المرفوعة لمدرسة معينة
    Task<IEnumerable<SubmittedStatistics>> GetSubmittedStatisticsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الإحصائية المرفوعة المرتبطة بمسودة محددة
    Task<SubmittedStatistics?> GetSubmittedStatisticsByDraftIdAsync(long statisticsDraftId, CancellationToken cancellationToken = default);
}

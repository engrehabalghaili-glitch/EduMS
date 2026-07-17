using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IStatisticsReportsArchiveRepository : IGenericRepository<StatisticsReportsArchive>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأرشيف بناءً على نوع التقرير المصدر
    Task<IEnumerable<StatisticsReportsArchive>> GetArchiveBySourceReportTypeAsync(string sourceReportType, CancellationToken cancellationToken = default);
    
    // جلب الأرشيف الذي انتهت فترة الاحتفاظ به ويحتاج إلى إتلاف
    Task<IEnumerable<StatisticsReportsArchive>> GetExpiredRetentionArchivesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب أرشيف التقارير الخاصة بمدرسة محددة
    Task<IEnumerable<StatisticsReportsArchive>> GetArchiveBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الأرشيف المرتبط بتقرير محدد
    Task<StatisticsReportsArchive?> GetArchiveBySourceReportIdAsync(long sourceReportId, string sourceReportType, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IStatisticsArchiveRepository : IGenericRepository<StatisticsArchive>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أرشيف الإحصائيات لسنة محددة
    Task<IEnumerable<StatisticsArchive>> GetArchivesByYearAsync(string archivedYear, CancellationToken cancellationToken = default);
    
    // جلب الأرشيف الذي انتهت فترة الاحتفاظ به (RetentionEndDate <= Now)
    Task<IEnumerable<StatisticsArchive>> GetExpiredRetentionArchivesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الأرشيف الخاص بمدرسة محددة
    Task<IEnumerable<StatisticsArchive>> GetArchivesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الأرشيف المرتبط بإحصائية مرفوعة معينة
    Task<StatisticsArchive?> GetArchiveBySubmittedStatisticsIdAsync(long submittedStatisticsId, CancellationToken cancellationToken = default);
}

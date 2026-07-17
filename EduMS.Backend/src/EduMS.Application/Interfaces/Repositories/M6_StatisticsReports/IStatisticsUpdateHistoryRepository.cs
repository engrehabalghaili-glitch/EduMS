using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IStatisticsUpdateHistoryRepository : IGenericRepository<StatisticsUpdateHistory>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات التحديث بناءً على التصنيف (طلاب، موظفين، أصول، مالية)
    Task<IEnumerable<StatisticsUpdateHistory>> GetUpdateHistoryByCategoryAsync(string changeCategory, CancellationToken cancellationToken = default);
    
    // جلب سجلات التحديث غير المعتمدة (IsApproved = false)
    Task<IEnumerable<StatisticsUpdateHistory>> GetUnapprovedUpdatesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات التحديث المرتبطة بمسودة إحصائية محددة
    Task<IEnumerable<StatisticsUpdateHistory>> GetUpdateHistoryByDraftIdAsync(long statisticsDraftId, CancellationToken cancellationToken = default);
    
    // جلب سجلات التحديث المرتبطة بإحصائية مرفوعة رسمياً
    Task<IEnumerable<StatisticsUpdateHistory>> GetUpdateHistoryBySubmittedStatisticsIdAsync(long submittedStatisticsId, CancellationToken cancellationToken = default);
}

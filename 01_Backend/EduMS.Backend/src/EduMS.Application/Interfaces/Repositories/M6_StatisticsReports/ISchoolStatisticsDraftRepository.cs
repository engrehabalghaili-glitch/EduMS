using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface ISchoolStatisticsDraftRepository : IGenericRepository<SchoolStatisticsDraft>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب مسودات الإحصائيات بناءً على حالتها (جديد، قيد العمل، جاهز للرفع، الخ)
    Task<IEnumerable<SchoolStatisticsDraft>> GetDraftsByStatusAsync(int draftStatus, CancellationToken cancellationToken = default);
    
    // جلب المسودات المقفلة (Locked) لمنع التعديل عليها
    Task<IEnumerable<SchoolStatisticsDraft>> GetLockedDraftsAsync(CancellationToken cancellationToken = default);
    
    // جلب المسودات بناءً على نوع الفترة (شهري، ربعي، سنوي)
    Task<IEnumerable<SchoolStatisticsDraft>> GetDraftsByPeriodTypeAsync(int periodType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب مسودات الإحصائيات الخاصة بمدرسة محددة
    Task<IEnumerable<SchoolStatisticsDraft>> GetDraftsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

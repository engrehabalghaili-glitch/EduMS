using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface ISystemReportRepository : IGenericRepository<SystemReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التقارير المنشورة
    Task<IEnumerable<SystemReport>> GetPublishedReportsAsync(CancellationToken cancellationToken = default);
    
    // جلب التقارير بناءً على نوع التقرير (ReportType)
    Task<IEnumerable<SystemReport>> GetReportsByTypeAsync(string reportType, CancellationToken cancellationToken = default);
    
    // جلب التقارير حسب حالة التقرير (مسودة، منشور، مؤرشف)
    Task<IEnumerable<SystemReport>> GetReportsByStatusAsync(int reportStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التقارير الخاصة بمدرسة محددة
    Task<IEnumerable<SystemReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

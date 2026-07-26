using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IComparativeReportRepository : IGenericRepository<ComparativeReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التقارير المقارنة بناءً على نوع المقارنة (بين فترات، بين مدارس، الخ)
    Task<IEnumerable<ComparativeReport>> GetReportsByComparisonTypeAsync(string comparisonType, CancellationToken cancellationToken = default);
    
    // جلب التقارير المقارنة المنشورة
    Task<IEnumerable<ComparativeReport>> GetPublishedReportsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التقارير المقارنة الخاصة بمدرسة محددة
    Task<IEnumerable<ComparativeReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

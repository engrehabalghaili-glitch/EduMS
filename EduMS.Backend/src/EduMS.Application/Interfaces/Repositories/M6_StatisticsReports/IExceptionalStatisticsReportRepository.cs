using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IExceptionalStatisticsReportRepository : IGenericRepository<ExceptionalStatisticsReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإحصائيات الاستثنائية التي تتضمن حوادث أو إغلاقات
    Task<IEnumerable<ExceptionalStatisticsReport>> GetReportsWithIncidentsOrClosuresAsync(CancellationToken cancellationToken = default);
    
    // جلب التقارير الاستثنائية المعتمدة
    Task<IEnumerable<ExceptionalStatisticsReport>> GetApprovedReportsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التقارير الاستثنائية الخاصة بمدرسة محددة
    Task<IEnumerable<ExceptionalStatisticsReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

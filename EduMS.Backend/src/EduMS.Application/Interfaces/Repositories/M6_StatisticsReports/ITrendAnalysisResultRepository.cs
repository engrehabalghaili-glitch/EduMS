using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface ITrendAnalysisResultRepository : IGenericRepository<TrendAnalysisResult>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تحليلات الاتجاه بناءً على الحالة (مسودة، معتمد)
    Task<IEnumerable<TrendAnalysisResult>> GetAnalysisResultsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب التحليلات بناءً على اتجاه المؤشر (تصاعدي، تنازلي، مستقر)
    Task<IEnumerable<TrendAnalysisResult>> GetAnalysisResultsByTrendDirectionAsync(string trendDirection, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تحليلات الاتجاه لمؤشر أداء معين (KpiCode)
    Task<IEnumerable<TrendAnalysisResult>> GetAnalysisResultsByKpiCodeAsync(string kpiCode, CancellationToken cancellationToken = default);
    
    // جلب التحليلات الخاصة بمدرسة محددة
    Task<IEnumerable<TrendAnalysisResult>> GetAnalysisResultsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

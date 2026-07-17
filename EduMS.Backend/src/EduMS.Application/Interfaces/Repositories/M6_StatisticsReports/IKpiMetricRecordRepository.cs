using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IKpiMetricRecordRepository : IGenericRepository<KpiMetricRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب القيم المسجلة بناءً على لون الحالة (أخضر، أصفر، أحمر)
    Task<IEnumerable<KpiMetricRecord>> GetMetricsByStatusColorAsync(string statusColor, CancellationToken cancellationToken = default);
    
    // جلب القيم التي تم تسجيلها في فترة محددة
    Task<IEnumerable<KpiMetricRecord>> GetMetricsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب القيم التي لم يتم التحقق منها بعد
    Task<IEnumerable<KpiMetricRecord>> GetUnverifiedMetricsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب قيم مؤشر أداء معين
    Task<IEnumerable<KpiMetricRecord>> GetMetricsByKpiConfigIdAsync(long kpiConfigId, CancellationToken cancellationToken = default);
    
    // جلب القيم المسجلة لمدرسة محددة
    Task<IEnumerable<KpiMetricRecord>> GetMetricsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

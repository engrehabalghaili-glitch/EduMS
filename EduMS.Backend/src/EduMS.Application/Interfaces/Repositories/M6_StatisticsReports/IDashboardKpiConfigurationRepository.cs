using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IDashboardKpiConfigurationRepository : IGenericRepository<DashboardKpiConfiguration>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب مؤشرات الأداء الفعالة
    Task<IEnumerable<DashboardKpiConfiguration>> GetActiveKpisAsync(CancellationToken cancellationToken = default);
    
    // جلب المؤشرات بناءً على وحدة النظام المصدر (طلاب، موظفين، مالية، أصول)
    Task<IEnumerable<DashboardKpiConfiguration>> GetKpisBySourceModuleAsync(string sourceModule, CancellationToken cancellationToken = default);
    
    // جلب المؤشرات التي مفعل فيها نظام التنبيهات (AlertEnabled = true)
    Task<IEnumerable<DashboardKpiConfiguration>> GetKpisWithAlertsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب إعدادات مؤشرات الأداء الخاصة بمدرسة محددة
    Task<IEnumerable<DashboardKpiConfiguration>> GetKpisBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار كود المؤشر
    Task<bool> IsKpiCodeUniqueAsync(string kpiCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

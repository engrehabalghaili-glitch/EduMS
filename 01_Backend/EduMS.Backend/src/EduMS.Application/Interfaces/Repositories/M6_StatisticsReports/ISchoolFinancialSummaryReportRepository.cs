using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface ISchoolFinancialSummaryReportRepository : IGenericRepository<SchoolFinancialSummaryReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تقارير الملخص المالي بناءً على السنة المالية
    Task<IEnumerable<SchoolFinancialSummaryReport>> GetReportsByFiscalYearAsync(string fiscalYear, CancellationToken cancellationToken = default);
    
    // جلب التقارير بناءً على حالة التدقيق (AuditStatus)
    Task<IEnumerable<SchoolFinancialSummaryReport>> GetReportsByAuditStatusAsync(string auditStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تقارير الملخص المالي الخاصة بمدرسة محددة
    Task<IEnumerable<SchoolFinancialSummaryReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IKpiFinancialPeriodLinkRepository : IGenericRepository<KpiFinancialPeriodLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الفترات المالية المرتبطة بسجل مؤشر أداء (KPI) محدد
    Task<IEnumerable<KpiFinancialPeriodLink>> GetLinksByKpiMetricRecordIdAsync(long kpiMetricRecordId, CancellationToken cancellationToken = default);
    
    // جلب المؤشرات المرتبطة بدورة رواتب معينة
    Task<IEnumerable<KpiFinancialPeriodLink>> GetLinksByPayrollRunIdAsync(long payrollRunId, CancellationToken cancellationToken = default);
    
    // جلب المؤشرات المرتبطة بقيد يومية محدد
    Task<IEnumerable<KpiFinancialPeriodLink>> GetLinksByJournalEntryIdAsync(long journalEntryId, CancellationToken cancellationToken = default);
    
    // جلب الروابط المتعلقة بفترة معينة (مثال: "2025-Q3")
    Task<IEnumerable<KpiFinancialPeriodLink>> GetLinksByPeriodLabelAsync(string periodLabel, CancellationToken cancellationToken = default);
}

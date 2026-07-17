using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetFinancialSummaryReportRepository : IGenericRepository<AssetFinancialSummaryReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التقارير المالية بناءً على حالة المراجعة/التدقيق
    Task<IEnumerable<AssetFinancialSummaryReport>> GetReportsByAuditStatusAsync(string auditStatus, CancellationToken cancellationToken = default);
    
    // جلب التقارير لعام مالي محدد
    Task<IEnumerable<AssetFinancialSummaryReport>> GetReportsByFiscalYearAsync(string fiscalYear, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التقارير المالية الخاصة بمدرسة معينة
    Task<IEnumerable<AssetFinancialSummaryReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب التقارير الخاصة بفئة أصول محددة (Asset Category)
    Task<IEnumerable<AssetFinancialSummaryReport>> GetReportsByAssetCategoryIdAsync(long assetCategoryId, CancellationToken cancellationToken = default);
}

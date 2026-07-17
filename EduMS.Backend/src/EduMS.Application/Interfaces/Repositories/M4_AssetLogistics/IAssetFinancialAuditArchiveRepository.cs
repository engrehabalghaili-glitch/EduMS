using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetFinancialAuditArchiveRepository : IGenericRepository<AssetFinancialAuditArchive>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأرشيف بناءً على نوع التقرير (إهلاك، قيمة دفترية، إعادة تقييم، سنوي)
    Task<IEnumerable<AssetFinancialAuditArchive>> GetArchivesByReportTypeAsync(int reportType, CancellationToken cancellationToken = default);
    
    // جلب الأرشيف بناءً على السنة المالية
    Task<IEnumerable<AssetFinancialAuditArchive>> GetArchivesByFiscalYearAsync(string fiscalYear, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الأرشيف الخاص بمدرسة محددة
    Task<IEnumerable<AssetFinancialAuditArchive>> GetArchivesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

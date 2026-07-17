using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetFinancialsRepository : IGenericRepository<AssetFinancials>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب البيانات المالية لأصل محدد
    Task<AssetFinancials?> GetFinancialsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب البيانات المالية لجميع أصول مدرسة محددة في سنة مالية معينة
    Task<IEnumerable<AssetFinancials>> GetFinancialsBySchoolAndFiscalYearAsync(long schoolId, string fiscalYear, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IDepreciationTransactionRepository : IGenericRepository<DepreciationTransaction>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب عمليات الإهلاك التي لم ترحل لدفتر الأستاذ (Ledger) بعد
    Task<IEnumerable<DepreciationTransaction>> GetUnpostedTransactionsAsync(CancellationToken cancellationToken = default);
    
    // جلب عمليات الإهلاك في سنة مالية محددة
    Task<IEnumerable<DepreciationTransaction>> GetTransactionsByFiscalYearAsync(string fiscalYear, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب عمليات الإهلاك المتعلقة بأصل محدد
    Task<IEnumerable<DepreciationTransaction>> GetTransactionsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب عمليات الإهلاك لمدرسة محددة
    Task<IEnumerable<DepreciationTransaction>> GetTransactionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

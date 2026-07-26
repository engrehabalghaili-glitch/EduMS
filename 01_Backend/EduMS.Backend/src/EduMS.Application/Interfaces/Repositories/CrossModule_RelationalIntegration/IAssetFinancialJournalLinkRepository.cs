using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IAssetFinancialJournalLinkRepository : IGenericRepository<AssetFinancialJournalLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط بناءً على نوع العملية المحاسبية (شراء، إهلاك، التخلص من الأصل)
    Task<IEnumerable<AssetFinancialJournalLink>> GetLinksByEntryTypeAsync(string entryType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب العمليات المالية المرتبطة بأصل محدد
    Task<IEnumerable<AssetFinancialJournalLink>> GetLinksBySchoolAssetIdAsync(long schoolAssetId, CancellationToken cancellationToken = default);
    
    // جلب العمليات المتعلقة بقيد يومية محدد
    Task<IEnumerable<AssetFinancialJournalLink>> GetLinksByJournalEntryIdAsync(long journalEntryId, CancellationToken cancellationToken = default);
}

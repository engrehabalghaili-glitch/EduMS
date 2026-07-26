using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetExpenseRepository : IGenericRepository<AssetExpense>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المصروفات بناءً على نوعها (رأسمالي Capex أو تشغيلي Opex)
    Task<IEnumerable<AssetExpense>> GetExpensesByTypeAsync(int expenseType, CancellationToken cancellationToken = default);
    
    // جلب المصروفات التي لم يتم رسملتها بعد (للأصول الرأسمالية)
    Task<IEnumerable<AssetExpense>> GetUncapitalizedExpensesAsync(CancellationToken cancellationToken = default);
    
    // جلب المصروفات التي لم تقيد مالياً بعد
    Task<IEnumerable<AssetExpense>> GetUnaccountedExpensesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع المصروفات المتعلقة بأصل محدد
    Task<IEnumerable<AssetExpense>> GetExpensesByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب المصروفات الخاصة بمدرسة معينة
    Task<IEnumerable<AssetExpense>> GetExpensesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

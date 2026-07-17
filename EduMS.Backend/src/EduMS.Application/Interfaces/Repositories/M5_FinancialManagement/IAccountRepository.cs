using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IAccountRepository : IGenericRepository<Account>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحسابات الفعالة
    Task<IEnumerable<Account>> GetActiveAccountsAsync(CancellationToken cancellationToken = default);
    
    // جلب الحسابات بناءً على نوع الحساب (أصول، خصوم، حقوق ملكية، إيرادات، مصروفات)
    Task<IEnumerable<Account>> GetAccountsByTypeAsync(int accountType, CancellationToken cancellationToken = default);
    
    // جلب الحسابات الرئيسية (التي ليس لها حساب أب، Level 1)
    Task<IEnumerable<Account>> GetRootAccountsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهيكلية (Foreign Keys and Hierarchy)
    // جلب الحسابات الفرعية التابعة لحساب أب محدد
    Task<IEnumerable<Account>> GetChildAccountsAsync(long parentAccountId, CancellationToken cancellationToken = default);
    
    // جلب الحسابات الخاصة بمدرسة محددة (إن وجدت كحسابات مخصصة لمدرسة)
    Task<IEnumerable<Account>> GetAccountsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الحساب
    Task<bool> IsAccountCodeUniqueAsync(string accountCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

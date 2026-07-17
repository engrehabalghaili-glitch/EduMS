using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IStudentAccountRepository : IGenericRepository<StudentAccount>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحسابات النشطة للطلاب
    Task<IEnumerable<StudentAccount>> GetActiveAccountsAsync(CancellationToken cancellationToken = default);
    
    // جلب حسابات الطلاب الذين عليهم رصيد متبقي (Outstanding Balance > 0)
    Task<IEnumerable<StudentAccount>> GetAccountsWithOutstandingBalanceAsync(CancellationToken cancellationToken = default);
    
    // جلب حسابات الطلاب المعفيين جزئياً أو كلياً من الرسوم
    Task<IEnumerable<StudentAccount>> GetExemptAccountsAsync(CancellationToken cancellationToken = default);
    
    // جلب حسابات الطلاب المحظورين من التسجيل بسبب المستحقات
    Task<IEnumerable<StudentAccount>> GetBlockedAccountsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب حساب الطالب بناءً على معرف الطالب
    Task<StudentAccount?> GetAccountByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب حسابات الطلاب في مدرسة محددة
    Task<IEnumerable<StudentAccount>> GetAccountsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

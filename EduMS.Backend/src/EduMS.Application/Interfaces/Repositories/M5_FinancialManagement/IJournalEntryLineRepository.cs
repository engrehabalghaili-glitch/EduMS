using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IJournalEntryLineRepository : IGenericRepository<JournalEntryLine>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تفاصيل القيد المحاسبي (الأسطر) التابعة لقيد محدد
    Task<IEnumerable<JournalEntryLine>> GetLinesByJournalEntryIdAsync(long journalEntryId, CancellationToken cancellationToken = default);
    
    // جلب حركات حساب محدد (أسطر القيود المرتبطة بهذا الحساب)
    Task<IEnumerable<JournalEntryLine>> GetLinesByAccountIdAsync(long accountId, CancellationToken cancellationToken = default);
}

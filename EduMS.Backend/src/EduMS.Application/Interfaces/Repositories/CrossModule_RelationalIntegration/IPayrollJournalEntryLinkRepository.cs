using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IPayrollJournalEntryLinkRepository : IGenericRepository<PayrollJournalEntryLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الروابط المحاسبية لسطر راتب محدد
    Task<IEnumerable<PayrollJournalEntryLink>> GetLinksByPayrollDetailIdAsync(long payrollDetailId, CancellationToken cancellationToken = default);
    
    // جلب الروابط المحاسبية الخاصة بقيد يومية محدد
    Task<IEnumerable<PayrollJournalEntryLink>> GetLinksByJournalEntryIdAsync(long journalEntryId, CancellationToken cancellationToken = default);
    
    // جلب الروابط الخاصة بموظف محدد
    Task<IEnumerable<PayrollJournalEntryLink>> GetLinksByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب قيود دورة رواتب معينة كاملة
    Task<IEnumerable<PayrollJournalEntryLink>> GetLinksByPayrollRunIdAsync(long payrollRunId, CancellationToken cancellationToken = default);
}

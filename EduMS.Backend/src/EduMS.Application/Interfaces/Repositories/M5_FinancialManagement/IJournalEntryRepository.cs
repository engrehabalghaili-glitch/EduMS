using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IJournalEntryRepository : IGenericRepository<JournalEntry>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب القيود بناءً على حالتها (مسودة، مرحلة)
    Task<IEnumerable<JournalEntry>> GetEntriesByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب القيود التي تمت في تاريخ معين أو فترة معينة
    Task<IEnumerable<JournalEntry>> GetEntriesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب القيود المحاسبية الخاصة بمدرسة معينة
    Task<IEnumerable<JournalEntry>> GetEntriesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

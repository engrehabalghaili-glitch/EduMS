using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IBehavioralLogRepository : IGenericRepository<BehavioralLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات السلوك خلال فترة زمنية محددة
    Task<IEnumerable<BehavioralLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب السجلات بناءً على التصنيف السلوكي (إيجابي، مخالفة بسيطة، مخالفة جسيمة)
    Task<IEnumerable<BehavioralLog>> GetLogsByCategoryAsync(int behaviorCategory, CancellationToken cancellationToken = default);
    
    // جلب السجلات بناءً على حالة المعالجة (قيد المراجعة، تمت المعالجة)
    Task<IEnumerable<BehavioralLog>> GetLogsByStatusAsync(int status, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة السجلات السلوكية الخاصة بطالب معين
    Task<IEnumerable<BehavioralLog>> GetLogsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب السجلات التي قام برصدها موظف محدد
    Task<IEnumerable<BehavioralLog>> GetLogsRecordedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

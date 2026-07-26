using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentDisciplinaryHistoryRepository : IGenericRepository<StudentDisciplinaryHistory>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار كود الإجراء التأديبي
    Task<bool> IsDisciplinaryActionCodeUniqueAsync(string actionCode, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإجراءات التأديبية المنفذة خلال فترة زمنية
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الإجراءات التأديبية بناءً على حالة الاستئناف (مقدم، مقبول، مرفوض)
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryByAppealStatusAsync(int appealStatus, CancellationToken cancellationToken = default);
    
    // جلب الإجراءات بناءً على حالتها الحالية (فعال، مكتمل، ملغي)
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryByStatusAsync(int status, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة السجل التأديبي لطالب معين
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الإجراءات التأديبية المرتبطة بسجل سلوكي معين
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryByBehavioralLogIdAsync(long behavioralLogId, CancellationToken cancellationToken = default);
    
    // جلب الإجراءات التي نفذها موظف محدد
    Task<IEnumerable<StudentDisciplinaryHistory>> GetDisciplinaryHistoryExecutedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

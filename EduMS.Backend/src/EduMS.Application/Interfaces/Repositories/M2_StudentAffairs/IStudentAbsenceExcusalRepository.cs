using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentAbsenceExcusalRepository : IGenericRepository<StudentAbsenceExcusal>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات الأعذار الطبية/الغياب المقدمة خلال فترة زمنية محددة
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب طلبات الأعذار بناءً على حالتها (قيد الانتظار، مقبول، مرفوض)
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsByStatusAsync(int reviewStatus, CancellationToken cancellationToken = default);
    
    // جلب الأعذار بناءً على نوعها (طبي، طارئ عائلي، مشاركة رسمية)
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsByTypeAsync(int excusalType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع طلبات الأعذار الخاصة بطالب معين
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات الأعذار التي قام برفعها ولي أمر محدد
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsSubmittedByGuardianAsync(long guardianId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي تمت مراجعتها من قبل موظف محدد
    Task<IEnumerable<StudentAbsenceExcusal>> GetExcusalsReviewedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

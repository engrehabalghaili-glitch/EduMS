using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentPreviousAcademicHistoryRepository : IGenericRepository<StudentPreviousAcademicHistory>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب السجلات الأكاديمية السابقة بناءً على حالة التحقق (معتمد، غير معتمد، مرفوض)
    Task<IEnumerable<StudentPreviousAcademicHistory>> GetAcademicHistoryByVerificationStatusAsync(int verificationStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب السجل الأكاديمي السابق لطالب محدد
    Task<IEnumerable<StudentPreviousAcademicHistory>> GetAcademicHistoryByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}

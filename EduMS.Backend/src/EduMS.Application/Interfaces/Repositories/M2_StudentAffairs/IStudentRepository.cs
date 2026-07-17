using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentRepository : IGenericRepository<Student>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // نمرر excludeId لتجاهل الطالب الحالي عند التعديل
    Task<bool> IsEnrollmentNumberUniqueAsync(string enrollmentNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة بالحالة (Status Filters)
    // جلب الطلاب الفعالين فقط
    Task<IEnumerable<Student>> GetActiveStudentsAsync(CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الطلاب في مدرسة معينة
    Task<IEnumerable<Student>> GetStudentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب جميع الطلاب في غرفة صفية معينة
    Task<IEnumerable<Student>> GetStudentsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب جميع الطلاب التابعين لولي أمر معين
    Task<IEnumerable<Student>> GetStudentsByGuardianIdAsync(long guardianId, CancellationToken cancellationToken = default);
}

using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentEnrollmentRepository : IGenericRepository<StudentEnrollment>
{
    // 1. الفلترة بالحالة والفصل الدراسي (Status and Term Filters)
    // جلب التسجيلات الفعالة فقط
    Task<IEnumerable<StudentEnrollment>> GetActiveEnrollmentsAsync(CancellationToken cancellationToken = default);
    
    // جلب التسجيلات الخاصة بالفصل الدراسي الحالي فقط
    Task<IEnumerable<StudentEnrollment>> GetCurrentTermEnrollmentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع التسجيلات الخاصة بطالب معين عبر تاريخه
    Task<IEnumerable<StudentEnrollment>> GetEnrollmentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب جميع التسجيلات في غرفة صفية معينة
    Task<IEnumerable<StudentEnrollment>> GetEnrollmentsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب التسجيلات التابعة لمدرسة معينة
    Task<IEnumerable<StudentEnrollment>> GetEnrollmentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);

    // 3. استعلامات مخصصة (Custom Queries)
    // جلب التسجيلات الخاصة بسنة أكاديمية محددة
    Task<IEnumerable<StudentEnrollment>> GetEnrollmentsByAcademicYearAsync(string academicYear, CancellationToken cancellationToken = default);
}

using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IAttendanceDetailRepository : IGenericRepository<AttendanceDetail>
{
    // 1. الفلترة بالتاريخ والحالة (Date and Status Filters)
    // جلب تفاصيل الحضور خلال فترة زمنية محددة
    Task<IEnumerable<AttendanceDetail>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب تفاصيل الحضور بناءً على حالة الحضور (حاضر، غائب، الخ)
    Task<IEnumerable<AttendanceDetail>> GetAttendanceByStatusAsync(int attendanceStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات الحضور الخاصة بطالب محدد
    Task<IEnumerable<AttendanceDetail>> GetAttendanceByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب سجلات الحضور الخاصة بفصل دراسي محدد
    Task<IEnumerable<AttendanceDetail>> GetAttendanceByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب سجلات الحضور التي تم تسجيلها بواسطة موظف محدد
    Task<IEnumerable<AttendanceDetail>> GetAttendanceRecordedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

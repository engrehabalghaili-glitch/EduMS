using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeAttendanceRepository : IGenericRepository<EmployeeAttendance>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الحضور لموظف معين في فترة محددة
    Task<IEnumerable<EmployeeAttendance>> GetAttendanceByEmployeeAndDateRangeAsync(long employeeId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب سجلات الحضور لجميع الموظفين في يوم محدد
    Task<IEnumerable<EmployeeAttendance>> GetAttendanceByDateAsync(DateTime attendanceDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات الحضور الخاصة بمدرسة محددة
    Task<IEnumerable<EmployeeAttendance>> GetAttendanceBySchoolIdAsync(long schoolId, DateTime attendanceDate, CancellationToken cancellationToken = default);
    
    // جلب سجلات الحضور الخاصة بإدارة/مديرية معينة
    Task<IEnumerable<EmployeeAttendance>> GetAttendanceByDirectorateIdAsync(long directorateId, DateTime attendanceDate, CancellationToken cancellationToken = default);
    
    // 3. الاستعلام عن حالات التأخير والغياب (Late and Absent)
    // جلب الموظفين المتأخرين في يوم محدد
    Task<IEnumerable<EmployeeAttendance>> GetLateAttendanceAsync(DateTime attendanceDate, CancellationToken cancellationToken = default);
    
    // جلب الموظفين الغائبين في يوم محدد
    Task<IEnumerable<EmployeeAttendance>> GetAbsentAttendanceAsync(DateTime attendanceDate, CancellationToken cancellationToken = default);
}

using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IClassScheduleRepository : IGenericRepository<ClassSchedule>
{
    // 1. التحقق من التعارض (Conflict Checking)
    // التحقق من أن المعلم ليس لديه حصة في نفس الوقت
    Task<bool> IsTeacherAvailableAsync(long employeeId, int dayOfWeek, int periodNumber, long? excludeScheduleId = null, CancellationToken cancellationToken = default);
    
    // التحقق من أن الفصل ليس لديه حصة في نفس الوقت
    Task<bool> IsClassroomAvailableAsync(long classroomId, int dayOfWeek, int periodNumber, long? excludeScheduleId = null, CancellationToken cancellationToken = default);
    
    // 2. الجلب المتخصص (Specific Retrieval)
    // جلب جدول فصل معين
    Task<IEnumerable<ClassSchedule>> GetScheduleByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب جدول معلم معين
    Task<IEnumerable<ClassSchedule>> GetScheduleByTeacherIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب جدول مدرسة كامل ليوم معين
    Task<IEnumerable<ClassSchedule>> GetSchoolScheduleByDayAsync(long schoolId, int dayOfWeek, CancellationToken cancellationToken = default);
}




using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface ITeacherScheduleRepository : IGenericRepository<TeacherSchedule>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب جداول الحصص الفعالة فقط
    Task<IEnumerable<TeacherSchedule>> GetActiveSchedulesAsync(CancellationToken cancellationToken = default);
    
    // جلب حصص الاحتياط (البديلة) التي تم إسنادها
    Task<IEnumerable<TeacherSchedule>> GetSubstituteSchedulesAsync(CancellationToken cancellationToken = default);
    
    // جلب الحصص الملغاة
    Task<IEnumerable<TeacherSchedule>> GetCancelledSchedulesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الجدول الأسبوعي لمعلم محدد
    Task<IEnumerable<TeacherSchedule>> GetSchedulesByTeacherIdAsync(long teacherEmployeeId, CancellationToken cancellationToken = default);
    
    // جلب جدول معلم محدد في يوم معين
    Task<IEnumerable<TeacherSchedule>> GetSchedulesByTeacherAndDayAsync(long teacherEmployeeId, string dayOfWeek, CancellationToken cancellationToken = default);
    
    // جلب جميع الحصص لغرفة صفية محددة
    Task<IEnumerable<TeacherSchedule>> GetSchedulesByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب جدول مادة معينة في مدرسة محددة
    Task<IEnumerable<TeacherSchedule>> GetSchedulesBySubjectAsync(long subjectId, long schoolId, CancellationToken cancellationToken = default);
}

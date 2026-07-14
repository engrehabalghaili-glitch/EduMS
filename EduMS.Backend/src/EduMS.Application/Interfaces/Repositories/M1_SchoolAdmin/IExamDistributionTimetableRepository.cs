using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IExamDistributionTimetableRepository : IGenericRepository<ExamDistributionTimetable>
{
    // 1. Conflict Checking
    // التحقق من أن المراقب (المعلم) متاح وليس لديه مراقبة أخرى في نفس الوقت
    Task<bool> IsProctorAvailableAsync(long proctorEmployeeId, DateTime examDate, string startTime, string endTime, long? excludeId = null);
    
    // التحقق من أن القاعة/المرفق متاح وليس محجوزاً لاختبار آخر
    Task<bool> IsFacilityAvailableAsync(long facilityId, DateTime examDate, string startTime, string endTime, long? excludeId = null);
    
    // 2. Specialized Retrieval
    // جلب جدول اختبارات صف دراسي معين
    Task<IEnumerable<ExamDistributionTimetable>> GetTimetableByClassroomAsync(long classroomId);
    
    // جلب جدول المراقبات الخاص بموظف (مراقب) معين
    Task<IEnumerable<ExamDistributionTimetable>> GetProctorScheduleAsync(long proctorEmployeeId);
}


using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentParentConferenceReservationRepository : IGenericRepository<StudentParentConferenceReservation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب حجوزات الاجتماعات بناءً على حالتها (مؤكد، مكتمل، ملغي)
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب الحجوزات بناءً على نوع الاجتماع (حضوري، فيديو، اتصال هاتفي)
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByTypeAsync(int conferenceType, CancellationToken cancellationToken = default);
    
    // جلب الاجتماعات التي تمت في تاريخ أو فترة زمنية محددة
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الاجتماعات التي حضرها ولي الأمر فعلياً (أو لم يحضرها)
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByAttendanceAsync(bool isGuardianAttended, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الاجتماعات الخاصة بطالب محدد
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الحجوزات التي قام بها ولي أمر محدد
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByGuardianIdAsync(long guardianId, CancellationToken cancellationToken = default);
    
    // جلب جدول اجتماعات معلم/موظف محدد مع أولياء الأمور
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByTeacherAsync(long teacherEmployeeId, CancellationToken cancellationToken = default);
    
    // جلب الاجتماعات المرتبطة بحدث معين في التقويم المدرسي (مثل يوم مفتوح للآباء)
    Task<IEnumerable<StudentParentConferenceReservation>> GetReservationsByEventIdAsync(long eventId, CancellationToken cancellationToken = default);
}

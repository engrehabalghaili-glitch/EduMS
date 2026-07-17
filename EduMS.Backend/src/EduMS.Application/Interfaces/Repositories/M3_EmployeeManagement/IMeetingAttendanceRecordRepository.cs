using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IMeetingAttendanceRecordRepository : IGenericRepository<MeetingAttendanceRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحضور لاجتماع محدد
    Task<IEnumerable<MeetingAttendanceRecord>> GetAttendanceByMeetingIdAsync(long meetingId, CancellationToken cancellationToken = default);
    
    // جلب الحاضرين (أو الغائبين) في اجتماع محدد
    Task<IEnumerable<MeetingAttendanceRecord>> GetAttendanceStatusByMeetingIdAsync(long meetingId, bool isAttended, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجل حضور موظف معين في كافة الاجتماعات
    Task<IEnumerable<MeetingAttendanceRecord>> GetAttendanceByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
}

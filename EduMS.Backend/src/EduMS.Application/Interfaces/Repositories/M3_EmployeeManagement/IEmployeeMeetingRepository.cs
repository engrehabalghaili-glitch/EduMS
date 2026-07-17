using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeMeetingRepository : IGenericRepository<EmployeeMeeting>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الاجتماعات بناءً على حالة الاجتماع (مجدول، منعقد، ملغي)
    Task<IEnumerable<EmployeeMeeting>> GetMeetingsByStatusAsync(int meetingStatus, CancellationToken cancellationToken = default);
    
    // جلب الاجتماعات التي ستعقد خلال فترة محددة
    Task<IEnumerable<EmployeeMeeting>> GetMeetingsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب اجتماعات لجنة محددة
    Task<IEnumerable<EmployeeMeeting>> GetMeetingsByCommitteeIdAsync(long committeeId, CancellationToken cancellationToken = default);
    
    // جلب الاجتماعات الخاصة بمدرسة معينة
    Task<IEnumerable<EmployeeMeeting>> GetMeetingsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

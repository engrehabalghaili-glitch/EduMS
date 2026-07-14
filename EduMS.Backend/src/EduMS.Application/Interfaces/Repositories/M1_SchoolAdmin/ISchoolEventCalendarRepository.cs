using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolEventCalendarRepository : IGenericRepository<SchoolEventCalendar>
{
    // 1. Date Queries
    // جلب فعاليات مدرسة معينة بين تاريخين
    Task<IEnumerable<SchoolEventCalendar>> GetEventsByDateRangeAsync(long schoolId, DateTime startDate, DateTime endDate);
    
    // 2. Type & Audience Filters
    // جلب الفعاليات حسب نوعها (عطلة، فترة اختبار، نشاط، مؤتمر)
    Task<IEnumerable<SchoolEventCalendar>> GetEventsByTypeAsync(long schoolId, int eventType);
    
    // جلب الفعاليات التي تستهدف جمهوراً محدداً (طلاب، أولياء أمور، موظفين)
    Task<IEnumerable<SchoolEventCalendar>> GetEventsByTargetAudienceAsync(long schoolId, int targetAudience);
    
    // 3. Status Filters
    // جلب الفعاليات العامة
    Task<IEnumerable<SchoolEventCalendar>> GetPublicEventsAsync(long schoolId);
}


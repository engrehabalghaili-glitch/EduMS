using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IUserActivityLogRepository : IGenericRepository<UserActivityLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب نشاطات المستخدم بناءً على نوع النشاط (دخول، خروج، تغيير كلمة مرور، الخ)
    Task<IEnumerable<UserActivityLog>> GetActivitiesByTypeAsync(string activityType, CancellationToken cancellationToken = default);
    
    // جلب النشاطات التي حدثت في فترة زمنية معينة
    Task<IEnumerable<UserActivityLog>> GetActivitiesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب نشاطات تسجيل الدخول الفاشلة
    Task<IEnumerable<UserActivityLog>> GetFailedLoginActivitiesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجل نشاطات مستخدم محدد
    Task<IEnumerable<UserActivityLog>> GetActivitiesByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    
    // جلب سجل نشاطات مستخدمين تابعين لمدرسة محددة
    Task<IEnumerable<UserActivityLog>> GetActivitiesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IAcademicLockPeriodRepository : IGenericRepository<AcademicLockPeriod>
{
    // 1. Status & Activity Filters
    // جلب فترات الإغلاق الأكاديمي النشطة حالياً للمدرسة
    Task<IEnumerable<AcademicLockPeriod>> GetActiveLockPeriodsAsync(long schoolId);
    
    // 2. Date queries
    // التحقق مما إذا كان هناك فترة إغلاق أكاديمي تغطي تاريخاً معيناً
    Task<bool> IsDateLockedAsync(long schoolId, DateTime date);
    
    // جلب جميع فترات الإغلاق ضمن نطاق زمني
    Task<IEnumerable<AcademicLockPeriod>> GetLockPeriodsByDateRangeAsync(long schoolId, DateTime startDate, DateTime endDate);
}


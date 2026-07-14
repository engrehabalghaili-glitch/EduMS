using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IGradingScaleBoundRepository : IGenericRepository<GradingScaleBound>
{
    // 1. Conflict & Unique Constraints
    // التحقق من أن كود التقييم (مثلاً A+) غير مكرر لنفس المقياس
    Task<bool> IsLetterCodeUniqueAsync(long schoolId, string scaleName, string letterCode, long? excludeId = null);
    
    // 2. Logic Methods
    // جلب التقييم المناسب لنسبة مئوية معينة (مثل إعطاء 85% فيرد بـ B)
    Task<GradingScaleBound?> GetGradeByPercentageAsync(long schoolId, string scaleName, decimal percentage);
    
    // جلب المقياس كاملاً مرتباً حسب الترتيب (DisplayOrder)
    Task<IEnumerable<GradingScaleBound>> GetFullScaleOrderedAsync(long schoolId, string scaleName);
}


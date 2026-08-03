using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolLevelRepository : IGenericRepository<SchoolLevel>
{
    // 1. Level Retrieval
    // جلب المراحل الدراسية الخاصة بالمدرسة مرتبة بحسب الترتيب (LevelOrder)
    Task<IEnumerable<SchoolLevel>> GetOrderedLevelsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 2. Conflict Checking
    // التحقق من أن ترتيب المرحلة (LevelOrder) غير مستخدم مسبقاً في نفس المدرسة
    Task<bool> IsLevelOrderUniqueAsync(long schoolId, int levelOrder, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 3. Logic Execution Support
    // جلب المرحلة التي تناسب عمراً معيناً للطالب بناءً على MinAge و MaxAge
    Task<SchoolLevel?> GetLevelByAgeAsync(long schoolId, int ageInYears, CancellationToken cancellationToken = default);
}




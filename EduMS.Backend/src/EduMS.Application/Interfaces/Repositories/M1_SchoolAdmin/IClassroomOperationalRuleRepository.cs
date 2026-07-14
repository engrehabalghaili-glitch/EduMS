using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IClassroomOperationalRuleRepository : IGenericRepository<ClassroomOperationalRule>
{
    // 1. Unique Constraints
    // التحقق من أن كود القاعدة التشغيلية غير مكرر داخل نفس الفصل
    Task<bool> IsRuleCodeUniqueAsync(long classroomId, string ruleCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Status Filters
    Task<IEnumerable<ClassroomOperationalRule>> GetActiveRulesAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // 3. Specific Logic
    // جلب القاعدة الفعالة الحالية بناءً على التاريخ
    Task<ClassroomOperationalRule?> GetEffectiveRuleByDateAsync(long classroomId, DateTime date, CancellationToken cancellationToken = default);
}




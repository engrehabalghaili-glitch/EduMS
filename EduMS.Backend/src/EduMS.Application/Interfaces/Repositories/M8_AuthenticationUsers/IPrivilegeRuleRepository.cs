using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IPrivilegeRuleRepository : IGenericRepository<PrivilegeRule>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب قواعد الامتيازات الفعالة
    Task<IEnumerable<PrivilegeRule>> GetActiveRulesAsync(CancellationToken cancellationToken = default);
    
    // جلب قواعد الامتيازات بناءً على التصنيف (تدقيق، موافقات، حدود، تنبيهات)
    Task<IEnumerable<PrivilegeRule>> GetRulesByCategoryAsync(string ruleCategory, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب القواعد الخاصة بمدرسة محددة
    Task<IEnumerable<PrivilegeRule>> GetRulesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

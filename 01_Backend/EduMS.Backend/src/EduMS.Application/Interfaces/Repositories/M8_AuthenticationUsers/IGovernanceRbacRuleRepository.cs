using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IGovernanceRbacRuleRepository : IGenericRepository<GovernanceRbacRule>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب قواعد الحوكمة التي تتطلب اعتماد
    Task<IEnumerable<GovernanceRbacRule>> GetRulesRequiringApprovalAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب قواعد الحوكمة الخاصة بدور محدد
    Task<IEnumerable<GovernanceRbacRule>> GetRulesByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
    
    // جلب القواعد التي تستهدف دوراً معيناً (TargetRoleId)
    Task<IEnumerable<GovernanceRbacRule>> GetRulesByTargetRoleIdAsync(long targetRoleId, CancellationToken cancellationToken = default);
}

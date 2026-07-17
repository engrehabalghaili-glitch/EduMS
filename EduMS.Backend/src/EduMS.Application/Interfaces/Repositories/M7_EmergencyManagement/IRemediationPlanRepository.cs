using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IRemediationPlanRepository : IGenericRepository<RemediationPlan>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب خطط المعالجة بناءً على الحالة (مسودة، معتمد، قيد التنفيذ، مكتمل)
    Task<IEnumerable<RemediationPlan>> GetPlansByStatusAsync(int planStatus, CancellationToken cancellationToken = default);
    
    // جلب خطط المعالجة بناءً على نوع الخطة (معالجة عجز، الاستفادة من فائض)
    Task<IEnumerable<RemediationPlan>> GetPlansByTypeAsync(int planType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب خطط المعالجة الخاصة بمدرسة محددة
    Task<IEnumerable<RemediationPlan>> GetPlansBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب خطط المعالجة المرتبطة بعجز محدد
    Task<IEnumerable<RemediationPlan>> GetPlansByDeficitIdAsync(long deficitId, CancellationToken cancellationToken = default);
    
    // جلب خطط المعالجة المرتبطة بفائض محدد
    Task<IEnumerable<RemediationPlan>> GetPlansBySurplusIdAsync(long surplusId, CancellationToken cancellationToken = default);
    
    // جلب الخطط التي يشرف على تنفيذها موظف محدد
    Task<IEnumerable<RemediationPlan>> GetPlansByExecutionLeadEmployeeIdAsync(long executionLeadEmployeeId, CancellationToken cancellationToken = default);
}

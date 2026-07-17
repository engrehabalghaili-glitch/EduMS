using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IEmergencyPlanRepository : IGenericRepository<EmergencyPlan>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب خطط الطوارئ الفعالة
    Task<IEnumerable<EmergencyPlan>> GetActiveEmergencyPlansAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب خطط الطوارئ الخاصة بمدرسة محددة
    Task<IEnumerable<EmergencyPlan>> GetEmergencyPlansBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الخطة
    Task<bool> IsPlanCodeUniqueAsync(string planCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

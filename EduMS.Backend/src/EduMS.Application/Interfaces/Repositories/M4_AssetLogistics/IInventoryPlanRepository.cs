using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IInventoryPlanRepository : IGenericRepository<InventoryPlan>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب خطط الجرد بناءً على حالة الخطة (مسودة، نشطة، مكتملة)
    Task<IEnumerable<InventoryPlan>> GetPlansByStatusAsync(int planStatus, CancellationToken cancellationToken = default);
    
    // جلب خطط الجرد بناءً على نوع الجرد (دوري، مفاجئ، جزئي)
    Task<IEnumerable<InventoryPlan>> GetPlansByTypeAsync(int inventoryType, CancellationToken cancellationToken = default);
    
    // جلب الخطط التي تتجاوز نسبة إنجاز معينة
    Task<IEnumerable<InventoryPlan>> GetPlansByMinimumCompletionAsync(decimal minCompletionPercentage, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب خطط الجرد التابعة لمدرسة محددة
    Task<IEnumerable<InventoryPlan>> GetPlansBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الخطط التي يديرها رئيس فريق (موظف) محدد
    Task<IEnumerable<InventoryPlan>> GetPlansByTeamLeaderAsync(long teamLeaderEmployeeId, CancellationToken cancellationToken = default);
}

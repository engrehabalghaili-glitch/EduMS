using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ISchoolDeficitRepository : IGenericRepository<SchoolDeficit>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب حالات العجز بناءً على الحالة (نشط، قيد المعالجة، محلول)
    Task<IEnumerable<SchoolDeficit>> GetDeficitsByStatusAsync(int deficitStatus, CancellationToken cancellationToken = default);
    
    // جلب حالات العجز بناءً على مستوى التأثير (عالي، حرج)
    Task<IEnumerable<SchoolDeficit>> GetDeficitsByImpactLevelAsync(int impactLevel, CancellationToken cancellationToken = default);
    
    // جلب حالات العجز بناءً على نوع العجز (معلمين، فصول، ميزانية، الخ)
    Task<IEnumerable<SchoolDeficit>> GetDeficitsByTypeAsync(string deficitType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب حالات العجز الخاصة بمدرسة محددة
    Task<IEnumerable<SchoolDeficit>> GetDeficitsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

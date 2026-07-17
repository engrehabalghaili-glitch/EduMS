using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ISafetySecurityReportRepository : IGenericRepository<SafetySecurityReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تقارير السلامة والأمان بناءً على مستوى السلامة (ممتاز، جيد، يحتاج تحسين)
    Task<IEnumerable<SafetySecurityReport>> GetReportsBySafetyLevelAsync(string safetyLevel, CancellationToken cancellationToken = default);
    
    // جلب التقارير التي تتطلب تجديد طفايات الحريق أو بها طفايات منتهية
    Task<IEnumerable<SafetySecurityReport>> GetReportsWithExpiredExtinguishersAsync(DateTime currentDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تقارير السلامة والأمان الخاصة بمدرسة محددة
    Task<IEnumerable<SafetySecurityReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

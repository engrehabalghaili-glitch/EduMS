using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolAccreditationLogRepository : IGenericRepository<SchoolAccreditationLog>
{
    // 1. Unique Constraints
    // التحقق من أن رقم الترخيص/الاعتماد غير مكرر
    Task<bool> IsLicenseNumberUniqueAsync(string licenseNumber, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Status Filters
    // جلب الاعتمادات السارية (التي لم تنتهِ صلاحيتها ولم تُعلق)
    Task<IEnumerable<SchoolAccreditationLog>> GetActiveAccreditationsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. Expiry Helpers
    // جلب الاعتمادات التي ستنتهي قريباً (خلال عدد معين من الأيام) لتنبيه الإدارة
    Task<IEnumerable<SchoolAccreditationLog>> GetExpiringAccreditationsAsync(long schoolId, int daysBeforeExpiry, CancellationToken cancellationToken = default);
}




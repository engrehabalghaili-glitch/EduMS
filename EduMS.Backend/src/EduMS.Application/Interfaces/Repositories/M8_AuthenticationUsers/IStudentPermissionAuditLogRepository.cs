using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IStudentPermissionAuditLogRepository : IGenericRepository<StudentPermissionAuditLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات التدقيق الخاصة بالصلاحيات التي تم منعها أو رفضها (WasAllowed = false)
    Task<IEnumerable<StudentPermissionAuditLog>> GetDeniedAccessLogsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات تدقيق صلاحيات طالب محدد
    Task<IEnumerable<StudentPermissionAuditLog>> GetLogsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب السجلات التي نفذها مستخدم محدد (من قام بالعملية)
    Task<IEnumerable<StudentPermissionAuditLog>> GetLogsByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    
    // جلب السجلات الخاصة بمدرسة محددة
    Task<IEnumerable<StudentPermissionAuditLog>> GetLogsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

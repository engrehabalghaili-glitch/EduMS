using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolAuditLogRepository : IGenericRepository<SchoolAuditLog>
{
    // 1. Filtering by Entity & Operation
    // جلب سجلات التدقيق الخاصة بجدول معين (مثل جدول الطلاب أو المعلمين)
    Task<IEnumerable<SchoolAuditLog>> GetAuditLogsByTableNameAsync(long schoolId, string tableName, CancellationToken cancellationToken = default);
    
    // جلب التغييرات التي طرأت على سجل (Entity) محدد بالمعرف الخاص به
    Task<IEnumerable<SchoolAuditLog>> GetAuditLogsByEntityIdAsync(long schoolId, string tableName, long entityId, CancellationToken cancellationToken = default);
    
    // 2. User Auditing
    // جلب الإجراءات التي قام بها مستخدم معين
    Task<IEnumerable<SchoolAuditLog>> GetAuditLogsByUserAsync(long schoolId, long userId, CancellationToken cancellationToken = default);
    
    // 3. Security & Severity
    // جلب السجلات المشبوهة أو التي تم وسمها بأنها عالية الخطورة (Critical)
    Task<IEnumerable<SchoolAuditLog>> GetSuspiciousOrCriticalLogsAsync(long schoolId, CancellationToken cancellationToken = default);
}




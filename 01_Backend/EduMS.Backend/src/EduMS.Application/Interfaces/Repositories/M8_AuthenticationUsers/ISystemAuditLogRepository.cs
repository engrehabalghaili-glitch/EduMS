using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface ISystemAuditLogRepository : IGenericRepository<SystemAuditLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات التدقيق بناءً على نوع العملية (INSERT, UPDATE, DELETE)
    Task<IEnumerable<SystemAuditLog>> GetLogsByActionTypeAsync(string actionType, CancellationToken cancellationToken = default);
    
    // جلب سجلات التدقيق المشبوهة (IsSuspicious = true)
    Task<IEnumerable<SystemAuditLog>> GetSuspiciousLogsAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات التدقيق التي تمت في تاريخ معين
    Task<IEnumerable<SystemAuditLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات التدقيق المرتبطة بمستخدم محدد
    Task<IEnumerable<SystemAuditLog>> GetLogsByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    
    // جلب سجلات التدقيق الخاصة بمدرسة محددة
    Task<IEnumerable<SystemAuditLog>> GetLogsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

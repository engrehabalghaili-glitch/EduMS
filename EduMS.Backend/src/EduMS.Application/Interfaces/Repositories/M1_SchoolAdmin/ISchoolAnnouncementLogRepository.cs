using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolAnnouncementLogRepository : IGenericRepository<SchoolAnnouncementLog>
{
    // 1. Filter by Target Audience
    // جلب الإعلانات الموجهة لجمهور محدد (طلاب، معلمين، الخ)
    Task<IEnumerable<SchoolAnnouncementLog>> GetAnnouncementsByAudienceAsync(long schoolId, int targetAudience, CancellationToken cancellationToken = default);
    
    // 2. Active & Pinned
    // جلب الإعلانات النشطة حالياً (تاريخ الانتهاء لم يحن بعد)
    Task<IEnumerable<SchoolAnnouncementLog>> GetActiveAnnouncementsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الإعلانات المثبتة (Pinned)
    Task<IEnumerable<SchoolAnnouncementLog>> GetPinnedAnnouncementsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. Sorting
    // جلب الإعلانات مرتبة بحسب الأولوية (Priority) وتاريخ النشر
    Task<IEnumerable<SchoolAnnouncementLog>> GetHighPriorityAnnouncementsAsync(long schoolId, CancellationToken cancellationToken = default);
}




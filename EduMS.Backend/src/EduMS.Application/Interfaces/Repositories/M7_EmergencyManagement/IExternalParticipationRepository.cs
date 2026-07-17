using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IExternalParticipationRepository : IGenericRepository<ExternalParticipation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المشاركات الخارجية بناءً على نوع الفعالية
    Task<IEnumerable<ExternalParticipation>> GetParticipationsByEventTypeAsync(string eventType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المشاركات الخارجية الخاصة بمدرسة محددة
    Task<IEnumerable<ExternalParticipation>> GetParticipationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

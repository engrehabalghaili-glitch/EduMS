using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IEmergencyHostingRepository : IGenericRepository<EmergencyHosting>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب حالات الاستضافة الطارئة بناءً على الحالة (فعالة، منتهية، الخ)
    Task<IEnumerable<EmergencyHosting>> GetHostingsByStatusAsync(int hostingStatus, CancellationToken cancellationToken = default);
    
    // جلب حالات الاستضافة بناءً على نوع الاستضافة (نازحين، طلاب من الخارج، الخ)
    Task<IEnumerable<EmergencyHosting>> GetHostingsByTypeAsync(string hostingType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب حالات الاستضافة الخاصة بمدرسة محددة
    Task<IEnumerable<EmergencyHosting>> GetHostingsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ISchoolSurplusRepository : IGenericRepository<SchoolSurplus>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب حالات الفائض بناءً على الحالة (مكتشف، قيد الاستفادة، تم الاستفادة منه)
    Task<IEnumerable<SchoolSurplus>> GetSurplusesByStatusAsync(int surplusStatus, CancellationToken cancellationToken = default);
    
    // جلب حالات الفائض بناءً على نوع الفائض (معلمين، تجهيزات، ميزانية، الخ)
    Task<IEnumerable<SchoolSurplus>> GetSurplusesByTypeAsync(string surplusType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب حالات الفائض المكتشفة في مدرسة محددة
    Task<IEnumerable<SchoolSurplus>> GetSurplusesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

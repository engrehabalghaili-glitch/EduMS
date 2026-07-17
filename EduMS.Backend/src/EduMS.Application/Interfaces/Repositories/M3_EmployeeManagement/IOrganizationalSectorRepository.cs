using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IOrganizationalSectorRepository : IGenericRepository<OrganizationalSector>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب القطاعات بناءً على نوعها (وزارة، مديرية، مدرسة، مستودع، الخ)
    Task<IEnumerable<OrganizationalSector>> GetSectorsByTypeAsync(int sectorType, CancellationToken cancellationToken = default);
    
    // جلب القطاعات التنظيمية النشطة
    Task<IEnumerable<OrganizationalSector>> GetActiveSectorsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهيكلية (Foreign Keys and Hierarchy)
    // جلب القطاعات الفرعية التابعة لقطاع رئيسي محدد
    Task<IEnumerable<OrganizationalSector>> GetSubSectorsAsync(long parentSectorId, CancellationToken cancellationToken = default);
    
    // جلب القطاع التنظيمي التابع لمديرية محددة
    Task<IEnumerable<OrganizationalSector>> GetSectorsByDirectorateIdAsync(long directorateId, CancellationToken cancellationToken = default);
    
    // جلب القطاع التنظيمي التابع لمدرسة محددة
    Task<IEnumerable<OrganizationalSector>> GetSectorBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب القطاعات التي يديرها موظف محدد
    Task<IEnumerable<OrganizationalSector>> GetSectorsByHeadEmployeeIdAsync(long headEmployeeId, CancellationToken cancellationToken = default);

    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود القطاع
    Task<bool> IsSectorCodeUniqueAsync(string sectorCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

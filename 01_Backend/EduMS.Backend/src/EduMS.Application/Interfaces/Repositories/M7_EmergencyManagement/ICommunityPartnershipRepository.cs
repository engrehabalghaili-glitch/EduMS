using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ICommunityPartnershipRepository : IGenericRepository<CommunityPartnership>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الشراكات المجتمعية الفعالة
    Task<IEnumerable<CommunityPartnership>> GetActivePartnershipsAsync(CancellationToken cancellationToken = default);
    
    // جلب الشراكات بناءً على نوع الدعم المقدم
    Task<IEnumerable<CommunityPartnership>> GetPartnershipsBySupportTypeAsync(string supportType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الشراكات المجتمعية الخاصة بمدرسة محددة
    Task<IEnumerable<CommunityPartnership>> GetPartnershipsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الشراكات التي يشرف عليها موظف محدد
    Task<IEnumerable<CommunityPartnership>> GetPartnershipsByResponsibleEmployeeIdAsync(long responsibleEmployeeId, CancellationToken cancellationToken = default);
}

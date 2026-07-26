using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;

public interface IAccessPolicyRepository : IGenericRepository<AccessPolicy>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سياسات الوصول الفعالة
    Task<IEnumerable<AccessPolicy>> GetActivePoliciesAsync(CancellationToken cancellationToken = default);
    
    // جلب سياسات الوصول بناءً على نوع السياسة (زمنية، مكانية، جهاز، IP)
    Task<IEnumerable<AccessPolicy>> GetPoliciesByTypeAsync(int policyType, CancellationToken cancellationToken = default);
    
    // جلب السياسات بناءً على أثرها (سماح، منع، تتطلب موافقة)
    Task<IEnumerable<AccessPolicy>> GetPoliciesByEffectAsync(int policyEffect, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سياسات الوصول الخاصة بمدرسة محددة
    Task<IEnumerable<AccessPolicy>> GetPoliciesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

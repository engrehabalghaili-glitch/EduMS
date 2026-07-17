using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IGuardianRepository : IGenericRepository<Guardian>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التحقق من عدم تكرار رقم العائلة
    Task<bool> IsFamilyNumberUniqueAsync(string familyNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أولياء الأمور المصرح لهم باستلام الطلاب
    Task<IEnumerable<Guardian>> GetAuthorizedPickupGuardiansAsync(CancellationToken cancellationToken = default);
    
    // جلب جهات الاتصال للطوارئ حسب الأولوية
    Task<IEnumerable<Guardian>> GetEmergencyContactsByPriorityAsync(int priority, CancellationToken cancellationToken = default);

    // 3. استعلامات بحث متقدمة (Advanced Search Queries)
    // البحث عن ولي أمر برقم العائلة
    Task<Guardian?> GetGuardianByFamilyNumberAsync(string familyNumber, CancellationToken cancellationToken = default);
}

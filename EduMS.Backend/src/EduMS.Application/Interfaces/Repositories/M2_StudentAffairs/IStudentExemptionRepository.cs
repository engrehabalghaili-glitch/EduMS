using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentExemptionRepository : IGenericRepository<StudentExemption>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التحقق من عدم تكرار كود الإعفاء المالي/الدراسي
    Task<bool> IsExemptionCodeUniqueAsync(string exemptionCode, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب كافة الإعفاءات الفعالة ضمن تاريخ الصلاحية
    Task<IEnumerable<StudentExemption>> GetActiveExemptionsAsync(CancellationToken cancellationToken = default);
    
    // جلب الإعفاءات بناءً على تصنيف الإعفاء (خصم رسوم، إعفاء مواصلات، الخ)
    Task<IEnumerable<StudentExemption>> GetExemptionsByCategoryAsync(int exemptionCategory, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الإعفاءات الخاصة بطالب محدد
    Task<IEnumerable<StudentExemption>> GetExemptionsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الإعفاءات التي تم الموافقة عليها من قبل موظف محدد
    Task<IEnumerable<StudentExemption>> GetExemptionsApprovedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeViolationRepository : IGenericRepository<EmployeeViolation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المخالفات بناءً على حالتها (قيد التحقيق، تم إصدار العقوبة، مستأنفة، مغلقة)
    Task<IEnumerable<EmployeeViolation>> GetViolationsByStatusAsync(int violationStatus, CancellationToken cancellationToken = default);
    
    // جلب المخالفات بناءً على تصنيفها (تأخير، سلوك، أداء، مالي، الخ)
    Task<IEnumerable<EmployeeViolation>> GetViolationsByCategoryAsync(int violationCategory, CancellationToken cancellationToken = default);
    
    // جلب المخالفات المسجلة خلال فترة زمنية محددة
    Task<IEnumerable<EmployeeViolation>> GetViolationsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة المخالفات المسجلة على موظف محدد
    Task<IEnumerable<EmployeeViolation>> GetViolationsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب المخالفات الخاصة بمدرسة معينة
    Task<IEnumerable<EmployeeViolation>> GetViolationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المخالفات التي يحقق فيها موظف/لجنة معينة
    Task<IEnumerable<EmployeeViolation>> GetViolationsUnderInvestigationByAsync(long investigatingEmployeeId, CancellationToken cancellationToken = default);
}

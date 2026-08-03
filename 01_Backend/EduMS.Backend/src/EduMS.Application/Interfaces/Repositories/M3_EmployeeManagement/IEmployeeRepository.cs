using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار الرمز الوظيفي
    Task<bool> IsEmployeeCodeUniqueAsync(string employeeCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // التأكد من عدم تكرار رقم الهوية الوطنية/الإقامة
    Task<bool> IsNationalIdUniqueAsync(string nationalId, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الموظفين بناءً على نوع الموظف (معلم، إداري، فني، الخ)
    Task<IEnumerable<Employee>> GetEmployeesByTypeAsync(int employeeType, CancellationToken cancellationToken = default);
    
    // جلب الموظفين بناءً على نوع العقد (دائم، مؤقت، الخ)
    Task<IEnumerable<Employee>> GetEmployeesByContractTypeAsync(int contractType, CancellationToken cancellationToken = default);
    
    // جلب الموظفين بناءً على حالة التوظيف (على رأس العمل، معار، مجاز، الخ)
    Task<IEnumerable<Employee>> GetEmployeesByEmploymentStatusAsync(int employmentStatus, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع موظفي مدرسة محددة
    Task<IEnumerable<Employee>> GetEmployeesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب جميع موظفي إدارة محددة (مديرية)
    Task<IEnumerable<Employee>> GetEmployeesByDirectorateIdAsync(long directorateId, CancellationToken cancellationToken = default);
    
    // جلب موظفي قسم أو قطاع محدد
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);

    // 4. البحث المتقدم والاعتماد (Search and Approval)
    // البحث عن الموظفين باستخدام الاسم أو الرمز الوظيفي أو الهوية
    Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm, CancellationToken cancellationToken = default);
    
    // جلب الموظفين غير المعتمدين (قيد المراجعة)
    Task<IEnumerable<Employee>> GetPendingVerificationEmployeesAsync(CancellationToken cancellationToken = default);
}

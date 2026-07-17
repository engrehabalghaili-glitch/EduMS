using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeAdditionalTaskRepository : IGenericRepository<EmployeeAdditionalTask>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المهام الإضافية بناءً على حالة المهمة (نشطة، مكتملة، ملغاة)
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksByStatusAsync(int taskStatus, CancellationToken cancellationToken = default);
    
    // جلب المهام الإضافية بناءً على نوعها (إشراف، عمل لجان، الخ)
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksByTypeAsync(int taskType, CancellationToken cancellationToken = default);
    
    // جلب المهام الإضافية التي تتضمن تعويضاً مالياً
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksWithFinancialCompensationAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة المهام الإضافية المسندة لموظف محدد
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب المهام الإضافية في مدرسة محددة
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المهام التي تم إسنادها بواسطة موظف/مدير محدد
    Task<IEnumerable<EmployeeAdditionalTask>> GetTasksAssignedByEmployeeAsync(long assignedByEmployeeId, CancellationToken cancellationToken = default);
}

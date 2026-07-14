using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    // 1. Unique Constraints
    // التحقق من أن كود القسم غير مكرر داخل نفس المدرسة
    Task<bool> IsDepartmentCodeUniqueAsync(long schoolId, string departmentCode, long? excludeId = null);
    
    // 2. Status Filters
    Task<IEnumerable<Department>> GetActiveDepartmentsAsync(long schoolId);
    
    // 3. Foreign Keys & Filtering
    // جلب جميع الأقسام التابعة لمدرسة معينة
    Task<IEnumerable<Department>> GetDepartmentsBySchoolIdAsync(long schoolId);
    
    // جلب الأقسام بناءً على نوعها (أكاديمي، إداري، مالي) داخل المدرسة
    Task<IEnumerable<Department>> GetDepartmentsByTypeAsync(long schoolId, int departmentType);
    
    // جلب القسم الذي يرأسه موظف معين
    Task<Department?> GetDepartmentByHeadEmployeeIdAsync(long headEmployeeId);
}


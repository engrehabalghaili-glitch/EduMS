using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolFacilityRepository : IGenericRepository<SchoolFacility>
{
    // 1. Unique Constraints
    // التحقق من أن كود المرفق غير مكرر داخل المدرسة
    Task<bool> IsFacilityCodeUniqueAsync(long schoolId, string facilityCode, long? excludeId = null);
    
    // 2. Status Filters
    // جلب المرافق الفعالة (التشغيلية)
    Task<IEnumerable<SchoolFacility>> GetOperationalFacilitiesAsync(long schoolId);
    
    // 3. Filtering by Type and Supervisor
    // جلب المرافق بناءً على نوعها (معمل، مكتبة، صالة، الخ)
    Task<IEnumerable<SchoolFacility>> GetFacilitiesByTypeAsync(long schoolId, int facilityType);
    
    // جلب المرافق التي يشرف عليها موظف معين
    Task<IEnumerable<SchoolFacility>> GetFacilitiesBySupervisorAsync(long supervisorId);
    
    // 4. Maintenance Queries
    // جلب المرافق التي تحتاج إلى صيانة أو قيد الإصلاح
    Task<IEnumerable<SchoolFacility>> GetFacilitiesRequiringMaintenanceAsync(long schoolId);
}


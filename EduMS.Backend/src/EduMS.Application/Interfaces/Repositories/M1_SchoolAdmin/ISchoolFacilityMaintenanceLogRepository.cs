using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolFacilityMaintenanceLogRepository : IGenericRepository<SchoolFacilityMaintenanceLog>
{
    // 1. Unique Constraints
    // التحقق من أن كود الصيانة غير مكرر
    Task<bool> IsMaintenanceCodeUniqueAsync(string maintenanceCode, long? excludeId = null);
    
    // 2. Status Filters
    // جلب طلبات الصيانة حسب الحالة (مجدولة، جارية، مكتملة، ملغاة)
    Task<IEnumerable<SchoolFacilityMaintenanceLog>> GetMaintenanceLogsByStatusAsync(long facilityId, int status);
    
    // 3. Date queries
    // جلب سجلات الصيانة ضمن نطاق زمني
    Task<IEnumerable<SchoolFacilityMaintenanceLog>> GetMaintenanceLogsByDateRangeAsync(long facilityId, DateTime startDate, DateTime endDate);
    
    // 4. Specific queries
    // جلب السجلات التي أشرف عليها موظف معين
    Task<IEnumerable<SchoolFacilityMaintenanceLog>> GetMaintenanceLogsByEmployeeIdAsync(long employeeId);
}


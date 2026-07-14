using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolTransportationRouteRepository : IGenericRepository<SchoolTransportationRoute>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود مسار النقل
    Task<bool> IsRouteCodeUniqueAsync(long schoolId, string routeCode, long? excludeId = null);
    
    // 2. Capacity Checks
    // جلب المسارات التي لا تزال تحتوي على مقاعد شاغرة
    Task<IEnumerable<SchoolTransportationRoute>> GetRoutesWithAvailableSeatsAsync(long schoolId);
    
    // 3. Employee Assignments
    // جلب المسارات المعينة لسائق محدد
    Task<IEnumerable<SchoolTransportationRoute>> GetRoutesByDriverAsync(long driverEmployeeId);
    
    // جلب المسارات المعينة لمشرف حافلة محدد
    Task<IEnumerable<SchoolTransportationRoute>> GetRoutesBySupervisorAsync(long supervisorEmployeeId);
}


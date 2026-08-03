using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IEmergencyIncidentRepository : IGenericRepository<EmergencyIncident>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحوادث الطارئة بناءً على الحالة (مفتوح، قيد المعالجة، مغلق، الخ)
    Task<IEnumerable<EmergencyIncident>> GetIncidentsByStatusAsync(int incidentStatus, CancellationToken cancellationToken = default);
    
    // جلب الحوادث بناءً على مستوى الخطورة (عالي، حرج، الخ)
    Task<IEnumerable<EmergencyIncident>> GetIncidentsBySeverityAsync(int severity, CancellationToken cancellationToken = default);
    
    // جلب الحوادث التي تم تفعيل خطة الطوارئ فيها
    Task<IEnumerable<EmergencyIncident>> GetIncidentsWithActivePlanAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الحوادث الخاصة بمدرسة محددة
    Task<IEnumerable<EmergencyIncident>> GetIncidentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الحوادث المرتبطة بخطة طوارئ معينة
    Task<IEnumerable<EmergencyIncident>> GetIncidentsByEmergencyPlanIdAsync(long emergencyPlanId, CancellationToken cancellationToken = default);
}

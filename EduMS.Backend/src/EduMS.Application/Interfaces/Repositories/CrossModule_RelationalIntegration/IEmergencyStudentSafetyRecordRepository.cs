using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmergencyStudentSafetyRecordRepository : IGenericRepository<EmergencyStudentSafetyRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات سلامة الطلاب بناءً على حالة السلامة (آمن، مصاب، مفقود، الخ)
    Task<IEnumerable<EmergencyStudentSafetyRecord>> GetRecordsBySafetyStatusAsync(int safetyStatus, CancellationToken cancellationToken = default);
    
    // جلب سجلات الطلاب الذين لم يتم إبلاغ أولياء أمورهم بعد
    Task<IEnumerable<EmergencyStudentSafetyRecord>> GetRecordsNotNotifiedToParentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجلات سلامة الطلاب أثناء حادثة طارئة محددة
    Task<IEnumerable<EmergencyStudentSafetyRecord>> GetRecordsByIncidentIdAsync(long emergencyIncidentId, CancellationToken cancellationToken = default);
    
    // جلب سجل سلامة طالب معين أثناء حادثة طوارئ محددة
    Task<EmergencyStudentSafetyRecord?> GetRecordByStudentAndIncidentAsync(long studentId, long emergencyIncidentId, CancellationToken cancellationToken = default);
}

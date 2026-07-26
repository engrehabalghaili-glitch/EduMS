using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmergencyIncidentAssetImpactRepository : IGenericRepository<EmergencyIncidentAssetImpact>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأصول المتأثرة بناءً على نوع التأثير (تضرر، دُمّر، نُشر)
    Task<IEnumerable<EmergencyIncidentAssetImpact>> GetImpactsByTypeAsync(int impactType, CancellationToken cancellationToken = default);
    
    // جلب الأصول التي تتطلب صيانة نتيجة للطوارئ
    Task<IEnumerable<EmergencyIncidentAssetImpact>> GetImpactsRequiringMaintenanceAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الأصول المتأثرة في حادثة طوارئ محددة
    Task<IEnumerable<EmergencyIncidentAssetImpact>> GetImpactsByIncidentIdAsync(long emergencyIncidentId, CancellationToken cancellationToken = default);
    
    // جلب سجلات تأثر أصل محدد بالطوارئ
    Task<IEnumerable<EmergencyIncidentAssetImpact>> GetImpactsByAssetIdAsync(long schoolAssetId, CancellationToken cancellationToken = default);
}

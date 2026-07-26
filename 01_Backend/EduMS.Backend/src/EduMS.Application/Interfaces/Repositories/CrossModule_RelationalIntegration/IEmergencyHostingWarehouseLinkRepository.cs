using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmergencyHostingWarehouseLinkRepository : IGenericRepository<EmergencyHostingWarehouseLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المستودعات المتصلة باستضافة طارئة محددة
    Task<IEnumerable<EmergencyHostingWarehouseLink>> GetLinksByHostingIdAsync(long emergencyHostingId, CancellationToken cancellationToken = default);
    
    // جلب حالات الاستضافة التي تم دعمها من مستودع محدد
    Task<IEnumerable<EmergencyHostingWarehouseLink>> GetLinksByWarehouseIdAsync(long warehouseId, CancellationToken cancellationToken = default);
    
    // جلب الروابط الخاصة بمدرسة محددة
    Task<IEnumerable<EmergencyHostingWarehouseLink>> GetLinksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

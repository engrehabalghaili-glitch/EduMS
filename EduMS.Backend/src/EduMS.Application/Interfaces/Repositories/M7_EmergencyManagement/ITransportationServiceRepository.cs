using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ITransportationServiceRepository : IGenericRepository<TransportationService>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب خطوط النقل الفعالة
    Task<IEnumerable<TransportationService>> GetActiveServicesAsync(CancellationToken cancellationToken = default);
    
    // جلب خطوط النقل بناءً على نوع الرحلة (صباحي، مسائي، طول اليوم)
    Task<IEnumerable<TransportationService>> GetServicesByTripTypeAsync(int tripType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب خدمات النقل الخاصة بمدرسة محددة
    Task<IEnumerable<TransportationService>> GetServicesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب خدمات النقل المرتبطة بحافلة معينة (AssetId)
    Task<IEnumerable<TransportationService>> GetServicesByBusAssetIdAsync(long busAssetId, CancellationToken cancellationToken = default);
    
    // جلب خدمات النقل المرتبطة بسائق محدد (EmployeeId)
    Task<IEnumerable<TransportationService>> GetServicesByDriverIdAsync(long driverEmployeeId, CancellationToken cancellationToken = default);
}

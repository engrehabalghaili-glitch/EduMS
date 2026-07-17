using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetLocationRecordRepository : IGenericRepository<AssetLocationRecord>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المواقع الفعالة
    Task<IEnumerable<AssetLocationRecord>> GetActiveLocationsAsync(CancellationToken cancellationToken = default);
    
    // جلب المواقع بناءً على نوعها (مبنى، طابق، غرفة، معمل)
    Task<IEnumerable<AssetLocationRecord>> GetLocationsByTypeAsync(int locationType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والهيكلية (Foreign Keys and Hierarchy)
    // جلب المواقع الفرعية التابعة لموقع أب محدد
    Task<IEnumerable<AssetLocationRecord>> GetSubLocationsAsync(long parentLocationId, CancellationToken cancellationToken = default);
    
    // جلب كافة المواقع في مبنى محدد وفي طابق محدد
    Task<IEnumerable<AssetLocationRecord>> GetLocationsByBuildingAndFloorAsync(string buildingName, int floorNumber, CancellationToken cancellationToken = default);
    
    // جلب المواقع الخاصة بمدرسة محددة
    Task<IEnumerable<AssetLocationRecord>> GetLocationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المواقع التي يقع تحت مسؤولية شخص/موظف محدد
    Task<IEnumerable<AssetLocationRecord>> GetLocationsByResponsiblePersonAsync(long responsiblePersonId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التحقق من عدم تكرار كود الموقع
    Task<bool> IsLocationCodeUniqueAsync(string locationCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

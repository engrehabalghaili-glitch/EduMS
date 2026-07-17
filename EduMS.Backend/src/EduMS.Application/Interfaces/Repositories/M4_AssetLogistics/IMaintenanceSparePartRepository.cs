using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IMaintenanceSparePartRepository : IGenericRepository<MaintenanceSparePart>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب قطع الغيار التي وصل مخزونها للحد الأدنى (تحتاج طلب جديد)
    Task<IEnumerable<MaintenanceSparePart>> GetLowStockPartsAsync(CancellationToken cancellationToken = default);
    
    // جلب قطع الغيار غير المتوفرة (Out of Stock)
    Task<IEnumerable<MaintenanceSparePart>> GetOutOfStockPartsAsync(CancellationToken cancellationToken = default);
    
    // جلب القطع الفعالة في النظام
    Task<IEnumerable<MaintenanceSparePart>> GetActivePartsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب قطع الغيار المتوفرة في مدرسة محددة
    Task<IEnumerable<MaintenanceSparePart>> GetPartsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار كود القطعة
    Task<bool> IsPartCodeUniqueAsync(string partCode, long? excludeId = null, CancellationToken cancellationToken = default);
}

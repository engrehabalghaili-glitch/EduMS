using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetWarrantyContractRepository : IGenericRepository<AssetWarrantyContract>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب العقود الفعالة حالياً
    Task<IEnumerable<AssetWarrantyContract>> GetActiveContractsAsync(CancellationToken cancellationToken = default);
    
    // جلب العقود التي اقترب موعد انتهائها (تحتاج تنبيه)
    Task<IEnumerable<AssetWarrantyContract>> GetExpiringContractsAsync(DateTime thresholdDate, CancellationToken cancellationToken = default);
    
    // جلب العقود بناءً على نوع العقد (ضمان، صيانة، ترخيص برمجيات، إيجار)
    Task<IEnumerable<AssetWarrantyContract>> GetContractsByTypeAsync(int contractType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب العقود الخاصة بمدرسة محددة
    Task<IEnumerable<AssetWarrantyContract>> GetContractsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}

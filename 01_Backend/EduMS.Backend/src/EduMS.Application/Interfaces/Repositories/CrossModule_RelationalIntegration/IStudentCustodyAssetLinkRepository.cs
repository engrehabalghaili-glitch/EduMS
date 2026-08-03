using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IStudentCustodyAssetLinkRepository : IGenericRepository<StudentCustodyAssetLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات العهد غير المسترجعة (الموجودة حالياً بحوزة الطالب)
    Task<IEnumerable<StudentCustodyAssetLink>> GetUnreturnedCustodiesAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات العهد التي تم إرجاعها بحالة تالفة أو مفقودة
    Task<IEnumerable<StudentCustodyAssetLink>> GetDamagedOrLostReturnsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب العهد بناءً على سجل استلام الطالب الأساسي
    Task<IEnumerable<StudentCustodyAssetLink>> GetLinksByStudentInventoryCustodyIdAsync(long studentInventoryCustodyId, CancellationToken cancellationToken = default);
    
    // جلب سجلات إعارة أصل ثابت محدد (SchoolAsset)
    Task<IEnumerable<StudentCustodyAssetLink>> GetLinksBySchoolAssetIdAsync(long schoolAssetId, CancellationToken cancellationToken = default);
    
    // جلب سجلات استلام صنف مخزون محدد (InventoryItem)
    Task<IEnumerable<StudentCustodyAssetLink>> GetLinksByInventoryItemIdAsync(long inventoryItemId, CancellationToken cancellationToken = default);
}

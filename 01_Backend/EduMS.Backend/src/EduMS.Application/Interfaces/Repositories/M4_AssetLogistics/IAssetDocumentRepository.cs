using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetDocumentRepository : IGenericRepository<AssetDocument>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الوثائق بناءً على نوع الوثيقة (فاتورة، صورة، دليل استخدام، الخ)
    Task<IEnumerable<AssetDocument>> GetDocumentsByTypeAsync(string docType, CancellationToken cancellationToken = default);
    
    // جلب الوثائق التي لم يتم التحقق منها بعد
    Task<IEnumerable<AssetDocument>> GetUnverifiedDocumentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الوثائق المرتبطة بأصل محدد
    Task<IEnumerable<AssetDocument>> GetDocumentsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب جميع الوثائق المرتبطة بعقد محدد
    Task<IEnumerable<AssetDocument>> GetDocumentsByContractIdAsync(long contractId, CancellationToken cancellationToken = default);
}

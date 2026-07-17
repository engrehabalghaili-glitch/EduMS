using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IMaintenanceExecutionRepository : IGenericRepository<MaintenanceExecution>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أعمال الصيانة بناءً على نوع التنفيذ (وقائي، استجابة، طارئ)
    Task<IEnumerable<MaintenanceExecution>> GetExecutionsByTypeAsync(int executionType, CancellationToken cancellationToken = default);
    
    // جلب أعمال الصيانة بناءً على حالتها (مكتمل، قيد التنفيذ، ملغى)
    Task<IEnumerable<MaintenanceExecution>> GetExecutionsByStatusAsync(int executionStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب أعمال الصيانة التي تمت على أصل محدد
    Task<IEnumerable<MaintenanceExecution>> GetExecutionsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب سجلات التنفيذ المرتبطة ببلاغ صيانة محدد
    Task<IEnumerable<MaintenanceExecution>> GetExecutionsByTicketIdAsync(long maintenanceTicketId, CancellationToken cancellationToken = default);
    
    // جلب أعمال الصيانة التي نفذها فني محدد
    Task<IEnumerable<MaintenanceExecution>> GetExecutionsByEmployeeAsync(long executedByEmployeeId, CancellationToken cancellationToken = default);
}

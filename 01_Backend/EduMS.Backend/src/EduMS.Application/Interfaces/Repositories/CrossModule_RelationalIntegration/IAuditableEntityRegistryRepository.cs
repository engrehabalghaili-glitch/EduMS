using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IAuditableEntityRegistryRepository : IGenericRepository<AuditableEntityRegistry>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الكيانات القابلة للتدقيق الفعالة
    Task<IEnumerable<AuditableEntityRegistry>> GetActiveEntitiesAsync(CancellationToken cancellationToken = default);
    
    // جلب الكيانات القابلة للتدقيق المصنفة كحساسة (IsSensitive = true)
    Task<IEnumerable<AuditableEntityRegistry>> GetSensitiveEntitiesAsync(CancellationToken cancellationToken = default);
    
    // جلب الكيانات القابلة للتدقيق التابعة لقسم (Module) محدد
    Task<IEnumerable<AuditableEntityRegistry>> GetEntitiesByModuleAsync(string sourceModule, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح والهوية (Keys and Identity)
    // جلب الكيان القابل للتدقيق عبر مفتاح الكيان (EntityTypeKey)
    Task<AuditableEntityRegistry?> GetEntityByKeyAsync(string entityTypeKey, CancellationToken cancellationToken = default);
}

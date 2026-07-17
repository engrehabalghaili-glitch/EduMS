using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IEducationalStageRepository : IGenericRepository<EducationalStage>
{
    // 1. Unique Constraints
    Task<bool> IsStageCodeUniqueAsync(string stageCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Status Filters
    Task<IEnumerable<EducationalStage>> GetActiveStagesAsync(CancellationToken cancellationToken = default);
    
    // 3. Custom Search & Ordering
    // جلب المراحل مرتبة حسب تسلسل العرض (DisplayOrder)
    Task<IEnumerable<EducationalStage>> GetStagesOrderedByDisplayAsync(CancellationToken cancellationToken = default);
    
    // البحث بواسطة كود منهج الوزارة
    Task<EducationalStage?> GetStageByMinistryCurriculumCodeAsync(string ministryCode, CancellationToken cancellationToken = default);
}




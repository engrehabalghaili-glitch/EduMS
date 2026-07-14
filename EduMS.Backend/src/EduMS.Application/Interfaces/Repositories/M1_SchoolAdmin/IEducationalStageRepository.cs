using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IEducationalStageRepository : IGenericRepository<EducationalStage>
{
    // 1. Unique Constraints
    Task<bool> IsStageCodeUniqueAsync(string stageCode, long? excludeId = null);
    
    // 2. Status Filters
    Task<IEnumerable<EducationalStage>> GetActiveStagesAsync();
    
    // 3. Custom Search & Ordering
    // جلب المراحل مرتبة حسب تسلسل العرض (DisplayOrder)
    Task<IEnumerable<EducationalStage>> GetStagesOrderedByDisplayAsync();
    
    // البحث بواسطة كود منهج الوزارة
    Task<EducationalStage?> GetStageByMinistryCurriculumCodeAsync(string ministryCode);
}


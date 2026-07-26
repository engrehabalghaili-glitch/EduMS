using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IAcademicBranchConfigLogRepository : IGenericRepository<AcademicBranchConfigLog>
{
    // 1. Config Retrieval
    // جلب قيمة إعداد معين بناءً على المفتاح (ConfigKey)
    Task<AcademicBranchConfigLog?> GetConfigByKeyAsync(long schoolId, string configKey, CancellationToken cancellationToken = default);
    
    // جلب الإعدادات بناءً على تصنيفها (أكاديمي، غياب، تقييم، أمان)
    Task<IEnumerable<AcademicBranchConfigLog>> GetConfigsByCategoryAsync(long schoolId, int category, CancellationToken cancellationToken = default);
    
    // 2. Approval Workflow
    // جلب الإعدادات التي تحتاج إلى موافقة مشرف (Pending Approval)
    Task<IEnumerable<AcademicBranchConfigLog>> GetPendingApprovalConfigsAsync(long schoolId, CancellationToken cancellationToken = default);
}




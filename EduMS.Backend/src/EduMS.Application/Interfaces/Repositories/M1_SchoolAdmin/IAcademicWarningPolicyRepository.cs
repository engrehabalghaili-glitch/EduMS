using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IAcademicWarningPolicyRepository : IGenericRepository<AcademicWarningPolicy>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود اللائحة
    Task<bool> IsPolicyCodeUniqueAsync(long schoolId, string policyCode, long? excludeId = null);
    
    // 2. Threshold Filtering
    // جلب لوائح التحذير بناءً على تصنيفها (أكاديمي، غياب، سلوك)
    Task<IEnumerable<AcademicWarningPolicy>> GetPoliciesByCategoryAsync(long schoolId, int warningCategory);
    
    // 3. Logic Execution Support
    // جلب اللائحة التي تتطابق مع القيمة التي تجاوزها الطالب (مثال: تجاوز نسبة الغياب المحددة)
    Task<AcademicWarningPolicy?> GetMatchingPolicyForThresholdAsync(long schoolId, int warningCategory, decimal actualValue);
}


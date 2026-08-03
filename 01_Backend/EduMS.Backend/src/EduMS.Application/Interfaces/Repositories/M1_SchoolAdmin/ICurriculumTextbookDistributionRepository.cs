using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ICurriculumTextbookDistributionRepository : IGenericRepository<CurriculumTextbookDistribution>
{
    // 1. Unique Constraints
    // التأكد من عدم تكرار كود الكتاب المخصص لمادة معينة في نفس المدرسة
    Task<bool> IsTextbookCodeUniqueAsync(long schoolId, long subjectId, string textbookCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Inventory Helpers
    // جلب الكتب المخصصة لمادة معينة
    Task<IEnumerable<CurriculumTextbookDistribution>> GetTextbooksBySubjectIdAsync(long subjectId, CancellationToken cancellationToken = default);
    
    // تتبع حالة التسليم: جلب السجلات التي لم يتم توزيع كامل الكمية المخصصة لها
    Task<IEnumerable<CurriculumTextbookDistribution>> GetPendingDistributionsAsync(long schoolId, CancellationToken cancellationToken = default);
}




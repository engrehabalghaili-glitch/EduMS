using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISubjectRepository : IGenericRepository<Subject>
{
    // 1. Unique Constraints
    // التحقق من أن كود المادة الدراسية غير مكرر داخل المدرسة
    Task<bool> IsSubjectCodeUniqueAsync(long schoolId, string subjectCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Status Filters
    Task<IEnumerable<Subject>> GetActiveSubjectsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. Filtering by Grade & Core
    // جلب المواد الدراسية بناءً على الصف الدراسي
    Task<IEnumerable<Subject>> GetSubjectsByGradeLevelAsync(long schoolId, int gradeLevel, CancellationToken cancellationToken = default);
    
    // جلب المواد الأساسية (Core Subjects) فقط
    Task<IEnumerable<Subject>> GetCoreSubjectsAsync(long schoolId, int? gradeLevel = null, CancellationToken cancellationToken = default);
    
    // 4. Custom Search
    // البحث عن مادة بالاسم أو التخصص
    Task<IEnumerable<Subject>> SearchSubjectsAsync(long schoolId, string searchTerm, CancellationToken cancellationToken = default);
}




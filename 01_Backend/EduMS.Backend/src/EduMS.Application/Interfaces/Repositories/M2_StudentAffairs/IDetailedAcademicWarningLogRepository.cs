using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IDetailedAcademicWarningLogRepository : IGenericRepository<DetailedAcademicWarningLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الإنذارات الأكاديمية خلال فترة زمنية معينة
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الإنذارات الأكاديمية حسب حالتها (نشط، تمت المعالجة، مصعّد)
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب الإنذارات بناءً على تصنيفها (ضعف درجات، كثرة غياب، الخ)
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsByCategoryAsync(int warningCategory, CancellationToken cancellationToken = default);
    
    // جلب كافة الإنذارات التي تم تصعيدها للإدارة
    Task<IEnumerable<DetailedAcademicWarningLog>> GetEscalatedWarningsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الإنذارات الأكاديمية الصادرة بحق طالب معين
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الإنذارات المرتبطة بمادة دراسية محددة
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsBySubjectIdAsync(long subjectId, CancellationToken cancellationToken = default);
    
    // جلب الإنذارات التي قام بإصدارها موظف محدد
    Task<IEnumerable<DetailedAcademicWarningLog>> GetWarningsIssuedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}

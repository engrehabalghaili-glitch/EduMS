using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IDirectorateStatisticalReportRepository : IGenericRepository<DirectorateStatisticalReport>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود التقرير
    Task<bool> IsReportCodeUniqueAsync(long directorateId, string reportCode, long? excludeId = null);
    
    // 2. Report Filtering
    // جلب التقارير بناءً على الفئة المستهدفة (طلاب، معلمين، الخ)
    Task<IEnumerable<DirectorateStatisticalReport>> GetReportsByCategoryAsync(long directorateId, int targetCategory);
    
    // جلب التقارير الخاصة بعام أكاديمي معين
    Task<IEnumerable<DirectorateStatisticalReport>> GetReportsByAcademicYearAsync(long directorateId, string academicYear);
    
    // 3. Status Filters
    // جلب التقارير التي تم التحقق منها أو نشرها للوزارة
    Task<IEnumerable<DirectorateStatisticalReport>> GetReportsByVerificationStatusAsync(long directorateId, int status);
}

